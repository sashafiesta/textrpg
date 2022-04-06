using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg
{
    class Clue
    {
        public string name;
        public Action[] actions;
        public bool canReturn;
        public string descripion;

        public Clue(string nam, string desc, Action[] actionsArr, bool canGoBack = true)
        {
            name = nam;
            descripion = desc;
            actions = actionsArr;
            canReturn = canGoBack;
        }
        public Clue(string nam, string desc, Action action, bool canGoBack = true)
        {
            name = nam;
            descripion = desc;
            actions = new Action[] { action };
            canReturn = canGoBack;
        }
    }
}
