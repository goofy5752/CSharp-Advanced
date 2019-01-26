using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam = new List<Person>();
        private List<Person> reserveTeam = new List<Person>();

        public Team(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<Person> FirstTeam
        {
            get { return firstTeam; }
        }

        public List<Person> ReserveTeam
        {
            get { return reserveTeam; }
        }

        public void AddPlayer(Person player)
        {
            if (player.Age < 40)
            {
                FirstTeam.Add(player);
            }
            else
            {
                ReserveTeam.Add(player);
            }
        }

        public override string ToString()
        {
            return $"First team has {firstTeam.Count} players." + Environment.NewLine + $"Reserve team has {reserveTeam.Count} players.";
        }
    }
}