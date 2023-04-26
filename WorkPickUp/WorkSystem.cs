using SampSharp.Entities;
using SampSharp.Entities.SAMP;
using SampSharp.Entities.SAMP.Commands;
using System;
using System.Linq;
using WorkPickUp.Data;
using WorkPickUp.Model;

namespace WorkPickUp
{
    public class WorkSystem : ISystem
    {
        //EntityManager entityManager = new EntityManager;
        readonly WorldService service = new WorldService(new EntityManager(), new NativeProxy<WorldServiceNative>());
        //IWorldService service;
        [Event]
        public void OnGameModeInit(IServerService serverService)
        {
            Console.WriteLine("\n----------------------------------");
            Console.WriteLine(" Blank game mode by your name here");
            Console.WriteLine("----------------------------------\n");


            //serverService.AddPlayerClass(8, new Vector3(0, 0, 7), 0);
            serverService.SetGameModeText("Blank game mode");
            //serverService.
            if (service.AddStaticPickup(19946, PickupType.ScriptedActionsOnlyEveryFewSeconds, new Vector3(9.9656d, 14.6787d, 3.1172d)))
                Console.WriteLine("Пикап добавлен");
        }
        /// <summary>
        /// не смог разобраться почему не вызываеться этот callback
        /// </summary>
        [Event]
        public void OnPlayerPickUpPickup(int player, int pickup)
        {
            Console.WriteLine("Пикап поднят");
        }

        
        [PlayerCommand("work")]
        public void HelloCommand(Player player)
        {
            Account account;
            using (SampContext context = new SampContext())
            {
                var workDialog = new InputDialog() {Content = "Work?", Button1 = "Work Start", Button2 = "Work Stop" };
                account = context.Accounts.First(x => x.Name == player.Name);
                if (account.IsWork) 
                {
                    player.SendClientMessage($"Hello {account.Name}, work stop!");
                    account.IsWork = false;
                }
                else
                {
                    player.SendClientMessage($"Hello {account.Name}, work start!");
                    account.IsWork = true;
                }
            }
        }

    }
}
