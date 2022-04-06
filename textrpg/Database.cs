using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg
{
    static class Database
    {
        public static Dictionary<string, Item> itemsDict = new Dictionary<string, Item>();
        public static Dictionary<ushort[], List<ushort[]>> connectionsDict = new Dictionary<ushort[], List<ushort[]>>(new WeirdThings.ConnectionsEqCmp());
        public static Dictionary<ushort[], Place> placesDict = new Dictionary<ushort[], Place>(new WeirdThings.ConnectionsEqCmp());
        public static Dictionary<string, Effect> effectsDict = new Dictionary<string, Effect>();
        public static void RegisterItems()
        {
            Item[] items = new Item[]
            {
                new ItemCommon()
                {
                    id = "main.item.noitem",
                    description = "Basically a Test Item",
                    name = "Test Item",
                },
                new ItemConsumeable(new Functions.Function[]
                { 
                    new(Functions.PlayerFunctions.ModifyHealth,-50 ),
                    new(Functions.PlayerFunctions.AddEffect, new object[]{"main.effect.testregen",10})
                })
                {
                    id = "main.item.useableitem",
                    description = "Basically a Useable Item",
                    name = "Useable Item",
                    RemoveOnConsume = true
                }
            };
            foreach (Item item in items)
                itemsDict.Add(item.id, item);
        }
        public static void RegisterConnections()
        {
            LocConnection[] locConnections = new LocConnection[]
            {
                new LocConnection(new ushort[] { 0 }, new ushort[] { 1 })
            };
            foreach (LocConnection locConnection in locConnections)
            {
                if (!connectionsDict.ContainsKey(locConnection.fPoint)) connectionsDict.Add(locConnection.fPoint, new List<ushort[]>());
                if (!connectionsDict.ContainsKey(locConnection.sPoint)) connectionsDict.Add(locConnection.sPoint, new List<ushort[]>());
                connectionsDict[locConnection.fPoint].Add(locConnection.sPoint);
                connectionsDict[locConnection.sPoint].Add(locConnection.fPoint);
            }
        }
        public static void RegisterPlaces()
        {
            Place[] places = new Place[]
            {
                new Place(new ushort[] {0}, "Позиция один", "Каменная платформа", new Clue("Нарисованный мелом круг", "Круг так и манит встать в центр", new Action("Встать в центр", "Вас перенесло в другую локацию", new Functions.Function(Functions.PlayerFunctions.Move,new ushort[] {1})))),
                new Place(new ushort[] {1}, "Позиция два", "Деревянная платформа")
            };
            foreach (Place place in places)
            {
                placesDict.Add(place.location, place);
            }
        }
        public static void RegisterEffects()
        {
            Effect[] effects = new Effect[]
            {
                new Effect("main.effect.testregen", "Регенерация", "Восстанавливает 10 здоровья/ход", new Functions.Function(Functions.PlayerFunctions.ModifyHealth, 10))
            };
            foreach (Effect effect in effects)
                effectsDict.Add(effect.id, effect);
        }
    }
}
