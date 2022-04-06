using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg
{

    class Effect
    {
        public string id;
		public string name;
        public string description;
        public Functions.Function[] OnStart;
        public Functions.Function[] OnTick;
        public Functions.Function[] OnElapsed;

		public Effect(string effectId, string nam, string desc, Functions.Function function)
		{
			id = effectId; name = nam; description = desc; OnTick = new Functions.Function[] { function };
		}
		public Effect(string effectId, string nam, string desc, Functions.Function[] function)
		{
			id = effectId; name = nam; description = desc; OnTick = function;
		}
		public Effect(string effectId, string nam, string desc, Functions.Function function, Functions.Function start, Functions.Function end)
		{
			id = effectId; name = nam; description = desc; OnTick = new Functions.Function[] { function }; OnStart = new Functions.Function[] { start }; OnElapsed = new Functions.Function[] { end };
		}
		public Effect(string effectId, string nam, string desc, Functions.Function function, Functions.Function[] start, Functions.Function[] end)
		{
			id = effectId; name = nam; description = desc; OnTick = new Functions.Function[] { function }; OnStart = start; OnElapsed = end;
		}
		public Effect(string effectId, string nam, string desc, Functions.Function[] function, Functions.Function[] start, Functions.Function[] end)
		{
			id = effectId; name = nam; description = desc; OnTick = function; OnStart = start; OnElapsed = end;
		}
	}
	class ActiveEffect
	{
		public string effectId;
		public uint duration;
		public object[] parameters;
		public bool keepDefaultParameters;
		public Effect effect => Database.effectsDict[effectId];
		public ActiveEffect(Effect effect, uint duration)
		{
			effectId = effect.id;
			this.duration = duration;
		}
		public ActiveEffect(Effect effect, uint duration, object[] param)
		{
			effectId = effect.id;
			this.duration = duration;
			parameters = param;
		}
		public ActiveEffect(string effect, uint duration)
		{
			effectId = effect;
			this.duration = duration;
		}
		public ActiveEffect(string effect, uint duration, object[] param)
		{
			effectId = effect;
			this.duration = duration;
			parameters = param;
		}
		public bool Tick(Player p)
		{
			if (duration < 1) return true;
			if (effect.OnTick.Length > 0)
			{
				if(!keepDefaultParameters) effect.OnTick[0].Invoke(p, parameters);
				else effect.OnTick[0].Invoke(p);
			}
			for (int i = 1; i < effect.OnTick.Length; i++)
            {
				effect.OnTick[i].Invoke(p);
			}
			duration--;
			return duration < 1;
		}
	}
}
