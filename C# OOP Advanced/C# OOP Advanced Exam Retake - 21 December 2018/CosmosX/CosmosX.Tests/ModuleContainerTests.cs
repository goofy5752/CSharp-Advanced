namespace CosmosX.Tests
{
    //using CosmosX.Entities.Containers;
    //using CosmosX.Entities.Modules.Absorbing;
    //using CosmosX.Entities.Modules.Energy;
    //using CosmosX.Entities.Modules.Energy.Contracts;
    //using Entities.Containers.Contracts;
    //using Entities.Modules.Absorbing.Contracts;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ModuleContainerTests
    {
        [Test]
        public void ValidateIsEnergyWorkCorrectly()
        {
            // Arrange
            int id = 1;
            int energyOutput = 20;
            IEnergyModule container = new CryogenRod(id, energyOutput);

            // Act
            var expected = container.EnergyOutput;

            // Assert
            Assert.AreEqual(energyOutput, expected);
        }
        [Test]
        public void ValidateTotalCount()
        {
            IContainer container = new ModuleContainer(20);
            int id = 1;
            int energyOutput = 20;
            IEnergyModule energyModule = new CryogenRod(id, energyOutput);
            IAbsorbingModule absorbingModule = new HeatProcessor(2, 20);
            container.AddEnergyModule(energyModule);
            container.AddAbsorbingModule(absorbingModule);
            int expected = 2;

            var total = container.ModulesByInput.Count;

            Assert.AreEqual(expected, total);
        }
        [Test]
        public void ValidateTotalOutput()
        {
            IContainer container = new ModuleContainer(20);

            IEnergyModule energyModule = new CryogenRod(10, 20);
            IAbsorbingModule absorbingModule = new HeatProcessor(11, 20);
            IAbsorbingModule absorbingModule1 = new CooldownSystem(12, 60);
            container.AddEnergyModule(energyModule);
            container.AddAbsorbingModule(absorbingModule);
            container.AddAbsorbingModule(absorbingModule1);
            int expectedEnergy = 20;
            int expectedAbsorb = 80;
            long realityEnergy = container.TotalEnergyOutput;
            long realityAbsorb = container.TotalHeatAbsorbing;

            Assert.AreEqual(expectedEnergy, realityEnergy);
            Assert.AreEqual(expectedAbsorb, realityAbsorb);
        }
        [Test]
        public void ValidateIsValidConstructor()
        {
            int totalModules = 4;
            IContainer container = new ModuleContainer(totalModules);
            IEnergyModule energyModule = new CryogenRod(10, 20);
            IAbsorbingModule absorbingModule = new HeatProcessor(11, 20);
            IAbsorbingModule absorbingModule1 = new CooldownSystem(12, 60);
            container.AddEnergyModule(energyModule);
            container.AddAbsorbingModule(absorbingModule);
            container.AddAbsorbingModule(absorbingModule1);

            int reality = container.ModulesByInput.Count;

            Assert.Greater(totalModules, reality);
        }
        [Test]
        public void ValidateIsAbsorbWorkCorrectly()
        {
            IContainer container = new ModuleContainer(30);
            int processorHeatId = 1;
            int cooldownSystemId = 2;
            int processorAbsorbOutput = 10;
            int cooldownSystemOutput = 11;
            IAbsorbingModule processorHeat = new HeatProcessor(processorHeatId, processorAbsorbOutput);
            IAbsorbingModule cooldownSystem = new CooldownSystem(cooldownSystemId, cooldownSystemOutput);

            int processorReality = processorHeat.HeatAbsorbing;
            int cooldownReality = cooldownSystem.HeatAbsorbing;

            Assert.AreEqual(processorAbsorbOutput, processorReality);
            Assert.AreEqual(cooldownSystemOutput, cooldownReality);
        }
    }
}