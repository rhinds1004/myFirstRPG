﻿using System;
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
        private int _experiencePoints;
        private string _name;
        private string _characterClass;
        private int _hitPoints;
        private int _level;
        private int _gold;
        private Weapon _currentWeapon;

      
        public string CharacterClass
        {
            get { return _characterClass; }
            set
            {
                _characterClass = value;
                OnPropertyChanged(nameof(CharacterClass));
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
   

        public ObservableCollection<QuestStatus> Quests { get; set; }   //isn't any backing variable defined. It is handled by the language?

        public Player()
        {
            Quests = new ObservableCollection<QuestStatus>(); //Even though the backing variable isn't defined by code language know what the variable is.
        }



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
    }
}
