using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateFrisbee
{
    public class Class1
    {
       
        public abstract class FrisbeeGame
        {
            public string Location { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public abstract void StartGame();
            public abstract void EndGame();
    }

        public class Player
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public Team Team { get; set; }
            public int GamesPlayed { get; set; }
            public void GetPlayerInfo()
            {
            
            }
        }

        public class Team
        {
            public string Name { get; set; }
            public List<Player> Players { get; set; }
            public Player Captain { get; set; }
            public Player Coach { get; set; }

            public void GetTeamInfo()
            {
            
            }
        }

        public class Event
        {
            public string Type { get; set; }
            public string Location { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public List<Player> Players { get; set; }
            public Team Winner { get; set; }
            public Team Loser { get; set; }

            public void GetEventInfo()
            {
            
            }
        }

        public abstract class OffensiveStrategy
        {
            public abstract void Method1();
            public abstract void Method2();
        }

        public abstract class DefensiveStrategy
        {
            public abstract void Method1();
            public abstract void Method2();
        }

        public class OffensePlayer : Player
        {
            public string Position { get; set; }
            public string Role { get; set; }

            public void GetOffensePlayerInfo()
            {
            
            }
        }

        public class DefensePlayer : Player
        {
            public string Position { get; set; }
            public string Role { get; set; }

            public void GetDefensePlayerInfo()
            {
            
            }
        }

        public interface IStrategy
        {
            void Method1();
            void Method2();
        }

        public interface IPlayerRole
        {
            string GetRole();
        }

    }
}
