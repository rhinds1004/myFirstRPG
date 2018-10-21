using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Engine.Models 
{
    public class Player : LivingEntity
    {
        #region Properties
        private int _experiencePoints;
     
        private string _characterClass;
      
        private Weapon _currentWeapon;

      
        public string CharacterClass
        {
            get { return _characterClass; }
            set
            {
                _characterClass = value;
                OnPropertyChanged();
            }
        }
       
        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            private set
            {
                _experiencePoints = value;
                OnPropertyChanged();
                SetLevelAndMaximumHitPoints();
            } 
        }

       

        public ObservableCollection<QuestStatus> Quests { get; }   

        #endregion

        public event EventHandler OnLevelUp;

        public Player(string name, string characterClass, int experiencePoints, int maximumHitPoints,
            int currentHitPoints, int gold): base(name, maximumHitPoints, currentHitPoints, gold)
        {
            CharacterClass = characterClass;
            ExperiencePoints = experiencePoints;
            Quests = new ObservableCollection<QuestStatus>(); //Even though the backing variable isn't defined by code language know what the variable is.
        }


        //TODO is this removed?
        public Weapon CurrentWeapon { get { return _currentWeapon; }
            set {
                    _currentWeapon = value;
                    OnPropertyChanged(nameof(CurrentWeapon));
            }
        }

    
        public bool HasAllTheseItems(List<ItemQuantity> items)
        {
            foreach (ItemQuantity item in items)
            {
                if(Inventory.Count(i=> i.ItemTypeID == item.ItemID) < item.Quantity)
                {
                    return false;
                }
            }
            return true;
        }

        public void AddExperience(int experiencePoints)
        {
            ExperiencePoints += experiencePoints;
        }

        private void SetLevelAndMaximumHitPoints()
        {
            int originalLevel = Level;

            Level = (ExperiencePoints / 100) + 1;

            if(Level != originalLevel)
            {
                MaximumHitPoints = Level * 10; //TODO add modifier(s) for different classes.
                OnLevelUp?.Invoke(this, System.EventArgs.Empty);
            }
        }
    }
}
