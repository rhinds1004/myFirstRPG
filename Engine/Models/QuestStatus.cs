using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class QuestStatus
    {
        public Quest PlayerQuest { get; set; }
        public bool IsCompleted { get; set; } //TODO doesn't update quest status

        public QuestStatus(Quest quest) //a arguement not need for IsCompleted as all quest will start out by being not completed.
        {
            PlayerQuest = quest;
            IsCompleted = false;
        }
    }
}
