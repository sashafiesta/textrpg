using System;
namespace TextRpg
{
    class Session
    {
        public enum EntryType : byte
        {
            Console, Discord, Telegram, Vk
        }
        public EntryType entryType;
        public DateTime logTime;
        public Session(EntryType type) { entryType = type; logTime = DateTime.Now; }
    }
}