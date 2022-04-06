using System;
using System.Numerics;
namespace TextRpg
{
    class Place
    {
        public ushort[] location;
        public string name;
        public string description;
        public Clue[] clues;

        public Place(ushort[] loc, string nam, string desc)
        {
            location = loc;
            name = nam;
            description = desc;
            clues = Array.Empty<Clue>();
        }

        public Place(ushort[] loc, string nam, string desc, Clue[] cls)
        {
            location = loc;
            name = nam;
            description = desc;
            clues = cls;
        }
        public Place(ushort[] loc, string nam, string desc, Clue cl)
        {
            location = loc;
            name = nam;
            description = desc;
            clues = new Clue[] { cl };
        }
    }
}