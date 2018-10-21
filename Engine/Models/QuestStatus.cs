using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class QuestStatus : BaseNotificationClass
    {
        private bool _isCompleted;

        public Quest PlayerQuest { get;}
        public bool IsCompleted
        {
            get { return _isCompleted; }

            set
            {
                _isCompleted = value;
                OnPropertyChanged();
            }
        }

        public QuestStatus(Quest quest) //a arguement not need for IsCompleted as all quest will start out by being not completed.
        {
            PlayerQuest = quest;
            IsCompleted = false;
        }
    }
}
