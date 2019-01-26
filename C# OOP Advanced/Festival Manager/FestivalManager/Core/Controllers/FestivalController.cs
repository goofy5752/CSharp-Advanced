namespace FestivalManager.Core.Controllers
{
    using Contracts;
    using Entities.Contracts;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;
    using System;
    using System.Linq;

    public class FestivalController : IFestivalController
    {
        private const string TimeFormat = "mm\\:ss";
        private const string TimeFormatLong = "{0:2D}:{1:2D}";
        private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";

        private readonly IInstrumentFactory instrumentFactory;
        private readonly IStage stage;
        private readonly ISetFactory setFactory;
        private readonly IPerformerFactory performerFactory;
        private readonly ISongFactory songFactory;

        public FestivalController(IStage stage)
        {
            this.stage = stage;
            this.setFactory = new SetFactory();
            this.performerFactory = new PerformerFactory();
            this.songFactory = new SongFactory();
            this.instrumentFactory = new InstrumentFactory();
        }

        public string RegisterSet(string[] args)
        {
            string name = args[0];
            string type = args[1];
            if (!this.stage.HasSet(name))
            {
                setFactory.CreateSet(name, type);
                return $"Registered {type} set";
            }
            else
            {
                return null;
            }

        }

        public string SignUpPerformer(string[] args)
        {
            var name = args[0];
            var age = int.Parse(args[1]);

            var instrumenti = args.Skip(2).ToArray();

            IPerformer performer = this.performerFactory.CreatePerformer(name, age);

            foreach (var instrument in instrumenti)
            {
                instrumentFactory.CreateInstrument(instrument);
            }

            if (!this.stage.HasPerformer(name))
            {
                this.stage.AddPerformer(performer);
                return $"Registered performer {performer.Name}";
            }
            else
            {
                return null;
            }
        }

        public string RegisterSong(string[] args)
        {
            var name = args[0];
            var timeSpan = TimeSpan.Parse(args[1]);
            var song = songFactory.CreateSong(name, timeSpan);

            if (!this.stage.HasSong(name))
            {
                this.stage.AddSong(song);
                return $"Registered song {song.ToString()}";
            }
            else
            {
                return null;
            }
        }

        public string AddSongToSet(string[] args)
        {
            var songName = args[0];
            var setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException("Invalid song provided");
            }

            var set = this.stage.GetSet(setName);
            var song = this.stage.GetSong(songName);

            set.AddSong(song);

            return $"Added {song.ToString()} to {set.Name}";
        }

        public string AddPerformerToSet(string[] args)
        {
            var performerName = args[0];
            var setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException("Invalid performer provided");
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            AddPerformerToSet(args);

            var performer = this.stage.GetPerformer(performerName);
            var set = this.stage.GetSet(setName);

            set.AddPerformer(performer);

            return $"Added {performer.Name} to {set.Name}";
        }

        public string RepairInstruments(string[] args)
        {
            var instrumentsToRepair = this.stage.Performers
                .SelectMany(p => p.Instruments)
                .Where(i => i.Wear <= 100)
                .ToArray();

            foreach (var instrument in instrumentsToRepair)
            {
                instrument.Repair();
            }

            return $"Repaired {instrumentsToRepair.Length} instruments";
        }

        public string ProduceReport()
        {
            throw new NotImplementedException();
        }
    }
}