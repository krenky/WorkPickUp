using SampSharp.Entities;
using SampSharp.Entities.SAMP;
using SampSharp.Entities.SAMP.Commands;
using System;
using System.Linq;
using WorkPickUp.Data;

namespace WorkPickUp
{
    public class LoginSystem : ISystem
    {
        private readonly SampContext _context;
        [Event]
        public void OnGameModeInit(IServerService serverService)
        {
            Console.WriteLine("\n----------------------------------");
            Console.WriteLine(" Blank game mode by your name here");
            Console.WriteLine("----------------------------------\n");

            
            serverService.AddPlayerClass(8, new Vector3(0, 0, 7), 0);
            serverService.SetGameModeText("Blank game mode");
            
            // TODO: Put logic to initialize your game mode here

        }
        [Event]
        public void OnPlayerConnect(Player player)
        {
            using (SampContext context = new SampContext())
            {
                //player.SendClientMessage($"Welcome {player.Name}, to a whole new world!");
                bool isContains = context.Accounts.Select(x => x.Name).Contains(player.Name);
                if (!isContains)
                {
                    player.SendClientMessage($"Hello newfish {player.Name}");
                    context.Accounts.Add(new Model.Account() { Name = player.Name, Password = "123456789" });
                    context.SaveChanges();
                }
                else
                {
                    player.SendClientMessage($"Hello, oldfish, {player.Name}");
                }
            }
        }
        //[Event]
        //public void OnPlayerSpawn(Player player)
        //{
        //    player.SendClientMessage($"Welcome {player.Name}, to a whole new world!");
        //}

        [PlayerCommand("hello")]
        public void HelloCommand(Player player)
        {
            player.SendClientMessage($"Hello, {player.Name}!");
        }
        [Event]
        public void OnPlayerPickUpPickup(Player player, Pickup pickup)
        {
            Console.WriteLine("Пикап поднят");
        }
    }
}