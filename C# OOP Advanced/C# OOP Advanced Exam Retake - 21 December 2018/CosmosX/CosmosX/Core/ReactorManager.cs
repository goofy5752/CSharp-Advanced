﻿using System;
using System.Collections.Generic;
using System.Linq;
using CosmosX.Core.Contracts;
using CosmosX.Entities.CommonContracts;
using CosmosX.Entities.Containers;
using CosmosX.Entities.Containers.Contracts;
using CosmosX.Entities.Modules.Absorbing;
using CosmosX.Entities.Modules.Absorbing.Contracts;
using CosmosX.Entities.Modules.Contracts;
using CosmosX.Entities.Modules.Energy;
using CosmosX.Entities.Modules.Energy.Contracts;
using CosmosX.Entities.Reactors;
using CosmosX.Entities.Reactors.Contracts;
using CosmosX.Entities.Reactors.ReactorFactory;
using CosmosX.Entities.Reactors.ReactorFactory.Contracts;
using CosmosX.Utils;

namespace CosmosX.Core
{
    public class ReactorManager : IManager
    {
        private int currentId;
        private readonly IDictionary<int, IIdentifiable> identifiableObjects;
        private readonly IDictionary<int, IReactor> reactors;
        private readonly IDictionary<int, IModule> modules;
        private readonly IReactorFactory reactorFactory;

        public ReactorManager()
        {
            this.currentId = Constants.StartingId;
            this.identifiableObjects = new Dictionary<int, IIdentifiable>();
            this.reactors = new Dictionary<int, IReactor>();
            this.modules = new Dictionary<int, IModule>();
            this.reactorFactory = new ReactorFactory();
        }

        public string ReactorCommand(IList<string> arguments)
        {
            string reactorType = arguments[0];
            int additionalParameter = int.Parse(arguments[1]);
            int moduleCapacity = int.Parse(arguments[2]);

            IContainer container = new ModuleContainer(moduleCapacity);

            IReactor reactor = reactorFactory.CreateReactor(reactorType, currentId, container, additionalParameter);

            this.reactors.Add(reactor.Id, reactor);
            this.identifiableObjects.Add(reactor.Id, reactor);

            this.currentId++;

            string result = string.Format(Constants.ReactorCreateMessage, reactorType, reactor.Id);
            return result;
        }

        public string ModuleCommand(IList<string> arguments)
        {
            int reactorId = int.Parse(arguments[0]);
            string moduleType = arguments[1];
            int additionalParameter = int.Parse(arguments[2]);

            switch (moduleType)
            {
                case "CryogenRod":
                    IEnergyModule cryogenRod = new CryogenRod(this.currentId, additionalParameter);
                    this.reactors[reactorId].AddEnergyModule(cryogenRod);
                    this.identifiableObjects.Add(cryogenRod.Id, cryogenRod);
                    this.modules.Add(cryogenRod.Id, cryogenRod);
                    break;
                case "HeatProcessor":
                    IAbsorbingModule heatProcessor = new HeatProcessor(this.currentId, additionalParameter);
                    this.reactors[reactorId].AddAbsorbingModule(heatProcessor);
                    this.identifiableObjects.Add(heatProcessor.Id, heatProcessor);
                    this.modules.Add(heatProcessor.Id, heatProcessor);
                    break;
                case "CooldownSystem":
                    IAbsorbingModule cooldownSytem = new CooldownSystem(this.currentId, additionalParameter);
                    this.reactors[reactorId].AddAbsorbingModule(cooldownSytem);
                    this.identifiableObjects.Add(cooldownSytem.Id, cooldownSytem);
                    this.modules.Add(cooldownSytem.Id, cooldownSytem);
                    break;
            }


            string result = string.Format(Constants.ModuleCreateMessage, moduleType, this.currentId++, reactorId);
            return result;
        }

        public string ReportCommand(IList<string> arguments)
        {
            int id = int.Parse(arguments[0]);

            if (reactors.Any(x => x.Key.Equals(id)))
            {
                return reactors[id].ToString();
            }

            if (modules.Any(x => x.Key.Equals(id)))
            {
                return modules[id].ToString();
            }

            return "Gosho";
            
        }

        public string ExitCommand(IList<string> arguments)
        {
            long cryoReactorCount = this.reactors
                .Values
                .Where(x => x.GetType().Name == "CryoReactor")
                .Count();

            long heatReactorCount = this.reactors
                .Values
                .Where(x => x.GetType().Name == "HeatReactor")
                .Count();

            long energyModulesCount = this.modules
                .Values
                .Where(x => x.GetType().Name == "CryogenRod")
                .Count();

            long absorbingModulesCount = this.modules
                .Values
                .Where(x => x.GetType().Name == "CooldownSystem" || x.GetType().Name == "HeatProcessor")
                .Count();

            long totalEnergyOutput = this.reactors
                .Values
                .Sum(r => r.TotalEnergyOutput);

            long totalHeatAbsorbing = this.reactors
                .Values
                .Sum(r => r.TotalHeatAbsorbing);

            string result = $"Cryo Reactors: {cryoReactorCount}\n" +                         
                            $"Heat Reactors: {heatReactorCount}\n" +              
                            $"Energy Modules: {energyModulesCount}\n" +                      
                            $"Absorbing Modules: {absorbingModulesCount}\n" +           
                            $"Total Energy Output: {totalEnergyOutput}\n" +
                            $"Total Heat Absorbing: {totalHeatAbsorbing}\n";

            return result.Trim();
        }
    }
}