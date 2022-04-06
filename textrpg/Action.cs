using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg
{
    class Action
    {
        public string interactionName;
        public Functions.Function[] functions;
        public Functions.Function[] conditions;
        public bool RequireAllConditions;

        public string messageDone;

        public Action(string name, string message, Functions.Function[] funcs, Functions.Function[] conds, bool reqAll = true)
        {
            interactionName = name;
            messageDone = message;
            functions = funcs;
            conditions = Enumerable.Concat(conds, new Functions.Function[] { new Functions.Function(Functions.PlayerFunctions.ExitClue) }).ToArray();
            RequireAllConditions = reqAll;
        }
        public Action(string name, string message, Functions.Function func, Functions.Function cond, bool reqAll = true)
        {
            interactionName = name;
            messageDone = message;
            functions = new Functions.Function[] { func };
            conditions = new Functions.Function[] { cond };
            RequireAllConditions = reqAll;
        }
        public Action(string name, string message, Functions.Function[] funcs)
        {
            interactionName = name;
            messageDone = message;
            functions = funcs;
            conditions = Array.Empty<Functions.Function>();
            RequireAllConditions = false;
        }
        public Action(string name, string message, Functions.Function func)
        {
            interactionName = name;
            messageDone = message;
            functions = new Functions.Function[] { func, new Functions.Function(Functions.PlayerFunctions.ExitClue) };
            conditions = Array.Empty<Functions.Function>();
            RequireAllConditions = false;
        }
    }
}
