using System.Threading.Channels;

namespace Woolworths.Groot.SmartSearch.Hubs
{
    public interface ISearchHub
    {
        Task ReceiveMessage(string user, string message);
    }
}
