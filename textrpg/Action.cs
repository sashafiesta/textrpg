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

        public Action(string name, Functions.Function[] funcs, Functions.Function[] conds, bool reqAll = true)
        {
            interactionName = name;
            functions = funcs;
            conditions = conds;
            RequireAllConditions = reqAll;
        }

        public Action(string name, Functions.Function[] funcs)
        {
            interactionName = name;
            functions = funcs;
            conditions = Array.Empty<Functions.Function>();
            RequireAllConditions = false;
        }
    }
}
