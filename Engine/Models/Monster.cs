using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Note: from the website. Inventory was passed in as a parameter as the author feels
 * this can lead to new temporary lists being created that have a short life.
 * Author likes to instaiate a new list variable in the constructor then wrap the add function
 * within AddItem function that can then have validation code before actually adding an item to
 * a list. Example code of issue:  https://gist.github.com/ScottLilly/717fba395154c445237011058c809c5b
 */ 
namespace Engine.Models
{
    public class Monster : LivingEntity
    {
        public string ImageName { get; set; }
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }

        public int RewardExperiencePoints { get; private set; }

        public Monster(string name, string imageName, int maximumHitPoints, int currentHitPoints,
            int minimumDamage, int maximumDamage,
            int rewardExperiencePoints, int gold) : base(name, maximumHitPoints, currentHitPoints, gold)
        {                                              
            ImageName = $"/Engine;component/Images/Monsters/{imageName}";
            MinimumDamage = minimumDamage;
            MaximumDamage = maximumDamage;
            RewardExperiencePoints = rewardExperiencePoints;  
        }
    }
}
