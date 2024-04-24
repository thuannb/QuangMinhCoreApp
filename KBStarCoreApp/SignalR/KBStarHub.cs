using KBStarCoreApp.Application.ViewModels.System;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace KBStarCoreApp.SignalR
{
    public class KBStarHub : Hub
    {
        public async Task SendMessage(AnnouncementViewModel message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
