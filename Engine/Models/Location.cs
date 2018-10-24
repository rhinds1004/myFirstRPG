using Engine.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Location
    {
        public int XCoordinate { get;  }
        public int YCoordinate  { get; }
        public string Name { get;  }
        public string Description { get;  }
        public string ImageName { get;  }
        public List<Quest> QuestsAvailableHere { get; set; } = new List<Quest>(); // this method initilizes the QuestAvaiableHere property with a new list without having to add the QuestAvaiableHere within the class constructor.

        public List<MonsterEncouter> MonstersHere { get; set; } = new List<MonsterEncouter>();

        public Trader TraderHere { get; set; }

        public Location(int xCoordinate, int yCoordinate, string name, string description, string imageName)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            Name = name;
            Description = description;
            ImageName = imageName;
        }

        public void AddMonster(int monsterID, int chanceOfEncountering)
        {
            if(MonstersHere.Exists(m => m.MonsterID == monsterID))
            {
                //Monster already at this location
                //Only chance of encountering monster is updated
                MonstersHere.First(m => m.MonsterID == monsterID)
                    .ChanceOfEncountering = chanceOfEncountering;
            }
            else
            {
                //The monster doesn't exist at this location, so add monster and is chance of being encountering

                MonstersHere.Add(new MonsterEncouter(monsterID, chanceOfEncountering));
            }
        }

        public Monster GetMonster()
        {
            if(!MonstersHere.Any())
            {
                return null;
            }

            //Total percentages of all monsters at this location
            int totalChances = MonstersHere.Sum(m => m.ChanceOfEncountering);

            //Select a random number between 1 and the total 9in case the total chances is not 100).
            int randomNumber = RandomNumberGenerator.NumberBetween(1, totalChances);

            //Loop through the monster list,
            //adding the monster's percentage chance of appearing to the runningTotal variable.
            // When the random number is lower than the runningTotal,
            // that us the monster to return.
            int runningTotal = 0;

            // This allows multiple monsters at a location. For each monster spawn at a location
            // there is a random check to see if the monster actually spawns.
            // The odds of encountering a given monster type is dependent on the monster type's
            //given encounter rate and the rate of monsters spawn at a given location.
            foreach(MonsterEncouter monsterEncounter in MonstersHere)
            {
                runningTotal += monsterEncounter.ChanceOfEncountering;
                if (randomNumber <= runningTotal)
                {
                    return MonsterFactory.GetMonster(monsterEncounter.MonsterID);
                }
            }

            //On the off chance there was a problem, returns the last monster in the list.
            return MonsterFactory.GetMonster(MonstersHere.Last().MonsterID);

        }
    }
}
