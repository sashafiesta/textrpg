using System;
using System.IO;
using System.Collections.Generic;
namespace TextRpg
{

    class Program
    {
		static void Main(string[] args)
        {
            Database.RegisterItems();
            Database.RegisterConnections();
            Database.RegisterPlaces();
            User ses = new User(0);
            ses.StartSession(Session.EntryType.Console);
            Player p = new Player() { health = 100 };
            ses.player = p;
            p.inventory.Add(new ItemStack(Database.itemdict["main.item.useableitem"]));

            while(true)
            {
                Console.Clear();

                Console.WriteLine(Interacting.GetFullStatus(p));
                Console.Write("> ");
                string command = Console.ReadLine();
                if (command == "exit") break;
                TextActionProcessor(command,ses);
            }
        }

        

        static bool TextActionProcessor(string command, User activeUser)
        {
            string[] cmdSplitted = command.Split();
            switch(cmdSplitted[0])
            {
                case "move":
                    {
                        activeUser.player.location = Database.connectionsdict[activeUser.player.location][Convert.ToInt32(cmdSplitted[1])-1];
                        return true;
                    }
                case "use":
                    {
                        foreach(ItemStack item in activeUser.player.inventory)
                        {
                            Item tmpitem = Database.itemdict[item.itemId];
                            if (Item.CanBeActivated(tmpitem))
                            {
                                if (tmpitem.name.ToLower().StartsWith(cmdSplitted[1].ToLower()))
                                {
                                    activeUser.player.ActivateItem((ItemActivable)tmpitem);
                                    activeUser.player.PerformTurn();
                                    return true;
                                }
                            }
                        }
                        return false;   
                    }
            }
            return false;
        }
    }
}
