using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg
{
    class Clue
    {   
        public Action[] interactionsF;
        public bool canReturn;

        public Clue(Action[] actions, bool canGoBack = true)
        {
            interactionsF = actions;
            canReturn = canGoBack;
        }
    }
}
