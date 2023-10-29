using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrisbeeGame
{
    internal class Program
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
                Console.WriteLine($"OffensePlayer: {Name}, Position: {Position}, Role: {Role}");
            }
        }

        public class DefensePlayer : Player
        {
            public string Position { get; set; }
            public string Role { get; set; }

            public void GetDefensePlayerInfo()
            {
                Console.WriteLine($"DefensePlayer: {Name}, Position: {Position}, Role: {Role}");
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
        static void MyMethod(object obj)
        {
            if (obj is OffensePlayer offensePlayer)
            {
                Console.WriteLine("Calling methods for OffensePlayer:");
                offensePlayer.GetPlayerInfo();
                offensePlayer.GetOffensePlayerInfo();
            }
            else if (obj is DefensePlayer defensePlayer)
            {
                Console.WriteLine("Calling methods for DefensePlayer:");
                defensePlayer.GetPlayerInfo();
                defensePlayer.GetDefensePlayerInfo();
            }
            else
            {
                Console.WriteLine("Object is not a valid player.");
            }
        }

        static void Main(string[] args)
        {
            OffensePlayer offensePlayer = new OffensePlayer
            {
                Id = 1,
                Name = "John",
                Team = new Team { Name = "Red Team" },
                GamesPlayed = 10,
                Position = "Cutter",
                Role = "Handler"
            };

            DefensePlayer defensePlayer = new DefensePlayer
            {
                Id = 2,
                Name = "Alice",
                Team = new Team { Name = "Blue Team" },
                GamesPlayed = 15,
                Position = "Handler",
                Role = "Marker"
            };

            MyMethod(offensePlayer);
            MyMethod(defensePlayer);
        }
    }
}
