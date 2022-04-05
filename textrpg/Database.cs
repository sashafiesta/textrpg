using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg
{
    static class Database
    {
        public static Dictionary<string, Item> itemdict = new Dictionary<string, Item>();
        public static Dictionary<ushort[], List<ushort[]>> connectionsdict = new Dictionary<ushort[], List<ushort[]>>(new WeirdThings.ConnectionsEqCmp());
        public static Dictionary<ushort[], Place> placesDict = new Dictionary<ushort[], Place>(new WeirdThings.ConnectionsEqCmp());
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
                new ItemConsumeable( new Functions.Function[]{ new(Functions.PlayerFunctions.ModifyHealth, new object[] { -50 }) })
                {
                    id = "main.item.useableitem",
                    description = "Basically a Useable Item",
                    name = "Useable Item",
                    RemoveOnConsume = true
                }
            };
            foreach (Item item in items)
                itemdict.Add(item.id, item);
        }
        public static void RegisterConnections()
        {
            LocConnection[] locConnections = new LocConnection[]
            {
                new LocConnection(new ushort[] { 0 }, new ushort[] { 1 })
            };
            foreach (LocConnection locConnection in locConnections)
            {
                if (!connectionsdict.ContainsKey(locConnection.fPoint)) connectionsdict.Add(locConnection.fPoint, new List<ushort[]>());
                if (!connectionsdict.ContainsKey(locConnection.sPoint)) connectionsdict.Add(locConnection.sPoint, new List<ushort[]>());
                connectionsdict[locConnection.fPoint].Add(locConnection.sPoint);
                connectionsdict[locConnection.sPoint].Add(locConnection.fPoint);
            }
        }
        public static void RegisterPlaces()
        {
            Place[] places = new Place[]
            {
                new Place(new ushort[] {0}, "Позиция один", "Каменная платформа"),
                new Place(new ushort[] {1}, "Позиция два", "Деревянная платформа")
            };
            foreach (Place place in places)
            {
                placesDict.Add(place.location, place);
            }
        }
    }
}
