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
            Database.RegisterEffects();
            User ses = new User(0);
            ses.StartSession(Session.EntryType.Console);
            Player p = new Player() { health = 100 };
            new Functions.Function(Functions.PlayerFunctions.ModifyHealth, -20).Invoke(p);
            ses.player = p;
            p.inventory.Add(new ItemStack(Database.itemsDict["main.item.useableitem"]));

            while(true)
            {
                Console.Clear();

                Console.WriteLine(Interacting.GetFullStatus(p));
                Console.Write("> ");
                string command = Console.ReadLine();
                if (command == "exit") break;
                if (TextActionProcessor(command, ses)) ses.player.PerformTurn();
            }
        }

        

        static bool TextActionProcessor(string command, User activeUser)
        {
            string[] cmdSplitted = command.Split();
            switch(cmdSplitted[0])
            {
                case "skip": return true;
                case "move":
                    {
                        activeUser.player.location = Database.connectionsDict[activeUser.player.location][Convert.ToInt32(cmdSplitted[1]) - 1];
                        return true;
                    }
                case "check":
                    {
                        Action[] local_checkAvailibleActions(Action[] actions, bool skippable)
                        {
                            List<Action> acts = new List<Action>();
                            foreach (Action a in actions)
                            {
                                int met = 0;
                                foreach (Functions.Function f in a.conditions)
                                    if (Convert.ToBoolean(f.Invoke(activeUser.player))) met++;
                                if (met < (a.RequireAllConditions ? a.conditions.Length : WeirdThings.IntMin(1, a.conditions.Length))) continue;
                                acts.Add(a);
                            }
                            if (skippable)
                                acts.Add(new Action("Вернуться", null, new Functions.Function(Functions.PlayerFunctions.ExitClue)));
                            return acts.ToArray();
                        }
                        string local_aggregateActions(Action[] actions)
                        {
                            string retV = "";
                            int i = 0;
                            foreach(Action a in actions)
                            {
                                retV += (++i) + ". " + a.interactionName + "\n";
                            }
                            return retV.TrimEnd();
                        }
                        Clue c = Database.placesDict[activeUser.player.location].clues[Convert.ToInt32(cmdSplitted[1]) - 1];
                        Action[] avActions = local_checkAvailibleActions(c.actions, c.canReturn);
                        while(true)
                        {
                            Console.Clear();
                            Console.WriteLine(c.descripion);
                            Console.WriteLine(local_aggregateActions(avActions));
                            int i = Convert.ToInt32(Console.ReadLine());
                            if (i < 1 || avActions.Length < i) continue;
                            foreach (Functions.Function f in avActions[i - 1].functions)
                                f.Invoke(activeUser.player);
                            string msg = avActions[i - 1].messageDone;
                            if (!(msg is null))
                            {
                                Console.WriteLine(avActions[i - 1].messageDone);
                                WeirdThings.Delay(500);
                            }
                            break;
                        }
                        return true;
                    }
                case "use":
                    {
                        foreach(ItemStack item in activeUser.player.inventory)
                        {
                            Item tmpitem = Database.itemsDict[item.itemId];
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
