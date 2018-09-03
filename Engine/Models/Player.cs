using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Engine.Models 
{
    public class Player : BaseNotificationClass
    {
        private int _experiencePoints;
        private string _name;
        private string _characterClass;
        private int _hitPoints;
        private int _level;
        private int _gold;
        private Weapon _currentWeapon;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string CharacterClass
        {
            get { return _characterClass; }
            set
            {
                _characterClass = value;
                OnPropertyChanged(nameof(CharacterClass));
            }
        }
        public int HitPoints
        {
            get { return _hitPoints; }           
            set
            {
                _hitPoints = value;
                OnPropertyChanged(nameof(HitPoints));             
            }
        }
        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set
            {
                _experiencePoints = value;
                OnPropertyChanged(nameof(ExperiencePoints));
            } 
        }
        public int Level {
            get { return _level; }
            set
            {
                _level = value;
                OnPropertyChanged(nameof(Level));
            }
        }
        public int Gold {
            get { return _gold; }
            set
            {
                _gold = value;
                OnPropertyChanged(nameof(Gold));
            }
        }   
        public ObservableCollection<GameItem> Inventory { get; set; }
        public List<GameItem> Weapons => Inventory.Where(i => i is Weapon).ToList();
        public ObservableCollection<QuestStatus> Quests { get; set; }   //isn't any backing variable defined. It is handled by the language?

        public Player()
        {
            Inventory = new ObservableCollection<GameItem>();
            Quests = new ObservableCollection<QuestStatus>(); //Even though the backing variable isn't defined by code language know what the variable is.
        }

        public void AddItemToInventory(GameItem item)
        {
            Inventory.Add(item);

            OnPropertyChanged(nameof(Weapons));
        }

        public Weapon CurrentWeapon { get { return _currentWeapon; }
            set {
                    _currentWeapon = value;
                    OnPropertyChanged(nameof(CurrentWeapon));

            }


        }

        public void RemoveItemFromInventory(GameItem item)
        {
            Inventory.Remove(item);
            OnPropertyChanged(nameof(Weapons));
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
    }
}
