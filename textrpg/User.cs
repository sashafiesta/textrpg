using System;

namespace TextRpg
{
    class User
    {
        public ulong userId;
        public ulong playerId;
        public Session session;
        public Player player;
        public User(ulong uId)
        {
            userId = uId;
        }
        public void StartSession(Session.EntryType entryType)
        {
            session = new Session(entryType);
        }
        public void StopSession()
        {
            session = null;
        }
    }
}
