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
            DoNothing, ModifyHealth, ExitClue, Move, AddEffect
        }
        private static readonly PlayerFunction[] PlayerFuncs =
        {
            //DoNothing()
            delegate(Player player, object[] param) { return null; },
            //ModifyHealth(float amount)
            delegate(Player player, object[] param) { player.health += Convert.ToDouble(param[0]); return null; },
            //ExitClue()
            delegate(Player player, object[] param) { player.inDialog = false; return null; },
            //Move(ushort[] location)
            delegate(Player player, object[] param) { player.location = (ushort[])param[0]; return null; },
            //AddEffect(string effectId, uint duration, object params)
            #warning TODO: Finish Function
            delegate(Player player, object[] param) { player.effects.Add(new ActiveEffect(Database.effectsDict[Convert.ToString(param[0])], 1+Convert.ToUInt32(param[1])){ keepDefaultParameters = true}); return null; }
        };
        public class Function
        {
            public PlayerFunctions Func;
            public object[] FunctionValue;
            public object Invoke(Player player)
                => PlayerFuncs[(uint)Func](player, FunctionValue);
            public object Invoke(Player player, object[] functionValue)
                => PlayerFuncs[(uint)Func](player, functionValue);

            public Function()
            {
                Func = PlayerFunctions.DoNothing;
                FunctionValue = Array.Empty<object>();
            }
            public Function(PlayerFunctions function)
            {
                Func = function;
                FunctionValue = Array.Empty<object>();
            }
            public Function(PlayerFunctions function, object functionval)
            {
                Func = function;
                FunctionValue = new object[] { functionval };
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
