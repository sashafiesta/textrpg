using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg
{
    class ItemStack
    {
        public uint amount;
        public string itemId;
        public string nbt;

        public string name => Database.itemsDict[itemId].name;
        public string description => Database.itemsDict[itemId].description;

        public ItemStack(Item item)
        {
            itemId = item.id;
            amount = 1;
            nbt = string.Empty;
        }
        public ItemStack(Item item, uint quantity)
        {
            itemId = item.id;
            amount = quantity;
            nbt = string.Empty;
        }
        public ItemStack(string item)
        {
            itemId = item;
            amount = 1;
            nbt = string.Empty;
        }
        public ItemStack(string item, uint quantity)
        {
            itemId = item;
            amount = quantity;
            nbt = string.Empty;
        }
    }
}
