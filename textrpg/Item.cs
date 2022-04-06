using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg
{
    abstract class Item
    {
        public enum ItemType
        {
            Common, Activable, Consumeable, Instant, Weapon, Wearable
        }
        public static bool CanBeActivated(Item item) => item.itemType == ItemType.Activable || item.itemType == ItemType.Consumeable;
        public string id;
        public string name;
        public string description;
        public uint maxStackSize;
        public ItemType itemType;
    }
    class ItemCommon : Item
    {
        public ItemCommon()
        {
            itemType = ItemType.Common;
        }
    }
    class ItemActivable : Item
    {
        public Functions.Function[] OnActivate;
        public bool RemoveOnConsume;
        public ItemActivable(Functions.Function[] onActivateF)
        {
            itemType = ItemType.Activable;
            OnActivate = onActivateF;
        }
    }
    class ItemConsumeable : ItemActivable
    {
        public ItemConsumeable(Functions.Function[] onActivateF) : base(onActivateF)
        {
            itemType = ItemType.Consumeable;
            OnActivate = onActivateF;
        }
    }
    class ItemInstant : ItemActivable
    {
        public ItemInstant(Functions.Function[] onActivateF) : base(onActivateF)
        {
            itemType = ItemType.Instant;
            OnActivate = onActivateF;
        }
    }
    class ItemWeapon : Item
    {
        public Damage damage;
        public Functions.Function[] OnHitTarget;
        public Functions.Function[] OnHitAttacker;
        public ItemWeapon(Functions.Function[] target, Functions.Function[] attacker)
        {
            OnHitTarget = target;
            OnHitAttacker = attacker;
            itemType = ItemType.Weapon;
            maxStackSize = 1;
        }
    }
    class ItemWearable : Item
    {
        enum GearType : byte
        {
            Boots,
            Armor,
            Clothes,
            Gloves,
            RingL,
            RingR,
            BraceletL,
            BraceletR,
            Goggles,
            HeadAccesories,
            Helmet,
            Bag//,
            //Shield
            //Cloak?
        }

        public Functions.Function Condition;
        public Functions.Function[] OnTurn;
        public Functions.Function[] OnHitTarget;
        public Functions.Function[] OnHitAttacker;
        public PlayerStats AddStats;
        public PlayerStats MulStats;
        public ItemWearable(Functions.Function function)
        {
            itemType = ItemType.Wearable;
            maxStackSize = 1;
        }
    }
}
