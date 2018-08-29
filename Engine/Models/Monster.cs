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
    public class Monster : BaseNotificationClass
    {
        private int _hitPoints;

        public string Name { get; set; }
        public string ImageName { get; set; }
        public int MaximumHitPoints { get; private set; }
        public int HitPoints
        {
            get { return _hitPoints; }
            set
            {
                _hitPoints = value;
                OnPropertyChanged(nameof(HitPoints));
            }
        }
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }

        public int RewardExperiencePoints { get; private set; }
        public int RewardGold { get; private set; }

        public ObservableCollection<ItemQuantity> Inventory { get; set; }

        public Monster(string name, string imageName, int maximumHitPoints, int hitPoints,
            int minimumDamage, int maximumDamage,
            int rewardExperiencePoints, int rewardGold)
        {                                              
            Name = name;
            ImageName = string.Format("/Engine;component/Images/Monsters/{0}", imageName);
            MaximumHitPoints = maximumHitPoints;
            HitPoints = hitPoints;
            MinimumDamage = minimumDamage;
            MaximumDamage = maximumDamage;
            RewardExperiencePoints = rewardExperiencePoints;
            RewardGold = RewardGold;
           

            Inventory = new ObservableCollection<ItemQuantity>();
        }
    }
}
