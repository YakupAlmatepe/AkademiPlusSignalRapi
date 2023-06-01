using AkademiPlusSignalRapi.Dal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademiPlusSignalRapi.Hubs
{
    public class MyHub : Hub
    { // kişiilerimi tutacak olan liste
        public static List<string> Names { get; set; } = new List<string>();
        //o anda kaç client bağlı olduğunu gösterir
        public static int ClientCount { get; set; } = 0;
        //bir odada max bulunacak kişi sayısı
        public static int RoomCount { get; set; } = 5;

        private readonly Context _context;

        public MyHub( Context context) //yapıcı metot oluşturuldu
        {
           
            _context = context;
        }
        public async Task sendname(string name)
        {
            Names.Add(name);
            await Clients.All.SendAsync("receivename", name);
        }
        public  override async Task OnConnectedAsync()
        {
            ClientCount++;
            await Clients.All.SendAsync("recieveclientcount", ClientCount);
        }
        public  override async Task OnDisconnectedAsync(Exception exception)
        {//bağlantı sayısı azaldığında gösterecek
            ClientCount--;
            await Clients.All.SendAsync("recieveclientcount", ClientCount);
        }
    }
}
