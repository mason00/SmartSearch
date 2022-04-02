using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;

namespace Woolworths.Groot.SmartSearch.Hubs
{
    public class SearchHub : Hub
    {
        public async Task SendMessage(string user, string message)
        => await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}
