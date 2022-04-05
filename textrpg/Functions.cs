using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg
{
    static class Functions
    {
        #region PlayerFunctions
        public delegate object PlayerFunction(Player player, params object[] param);
        public enum PlayerFunctions : uint
        {
            DoNothing, ModifyHealth
        }
        private static readonly PlayerFunction[] PlayerFuncs =
        {
            //DoNothing()
            delegate(Player player, object[] param) { return null; },
            //ModifyHealth(float amount)
            delegate(Player player, object[] param) { player.health += Convert.ToDouble(param[0]); return null; }
        };
        public class Function
        {
            public PlayerFunctions Func;
            public object[] FunctionValue;
            public object Invoke(Player player)
                => PlayerFuncs[(uint)Func](player, FunctionValue);

            public Function()
            {
                Func = PlayerFunctions.DoNothing;
                FunctionValue = Array.Empty<object>();
            }
            public Function(PlayerFunctions function, object[] functionval)
            {
                Func = function;
                FunctionValue = functionval;
            }
        }
        #endregion
    }
}
