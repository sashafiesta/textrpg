using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg
{
    static class Interacting
    {
        private static string AggregateInventory(in List<ItemStack> itemstacks)
        {
            string list = "";
            foreach (ItemStack i in itemstacks) list += i.name + "\n";
            return list.TrimEnd();
        }
        private static string AggregateLocation(ushort[] location)
        {
            string loc = "";
            foreach (ushort i in location) loc += i.ToString() + ", ";
            return loc.TrimEnd().TrimEnd(',');
        }
        private static string AggregateConnections(ushort[] location)
        {
            string loc = "";
            int j = 1;
            foreach (ushort[] i in Database.connectionsdict[location]) loc += j++ + ". " + Database.placesDict[i].name + "\n";
            return loc.TrimEnd().TrimEnd(',');
        }
        private static string AggregateClues(ushort[] location)
        {
            string loc = "";
            int j = 1;
            foreach (Clue i in Database.placesDict[location].clues) loc += j++ + ". " + i.name + "\n";
            return loc.TrimEnd().TrimEnd(',');
        }

        public static string GetFullStatus(Player player)
        {
            return @$"Вы в {Database.placesDict[player.location].name + " {" + AggregateLocation(player.location) + "} - " + Database.placesDict[player.location].description}
У Вас {player.healthInt}/{player.currentStats.maxHealth} здоровья и {player.mana}/{player.currentStats.maxMana} маны
У Вас в инвентаре({player.inventory.Count}/{player.currentStats.inventorySize}):
{AggregateInventory(in player.inventory)}
Вы можете пойти в:
{AggregateConnections(player.location)}
Вы можете осмотреть:
{AggregateClues(player.location)}
";
        }
    }
}
