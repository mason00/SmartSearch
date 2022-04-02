using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;
using System.Reactive.Subjects;
using System.Threading.Channels;

namespace Woolworths.Groot.SmartSearch.Hubs
{
    public class SearchHub : Hub<ISearchHub>
    {
        private readonly FullTextSearchStreamSource fullTextSearchStreamSource;

        public Channel<string> fullTextSearchChannel { get; set; }

        public SearchHub(FullTextSearchStreamSource fullTextSearchStreamSource)
        {
            fullTextSearchChannel = Channel.CreateUnbounded<string>();
            this.fullTextSearchStreamSource = fullTextSearchStreamSource;
        }

        public async Task SendMessage(string user, string message)
        => await Clients.All.ReceiveMessage(user, message);

        public ChannelReader<string> FullTextSearchChannel()
        {
            //WriteToFullTextSearchChannle(channel, "initial");
            //return fullTextSearchChannel.Reader;

            //return fullTextSearchStreamSource.StreamMesage().AsChannelReader();

            return fullTextSearchStreamSource.CreateChannelForClient();

            //return fullTextSearchStreamSource.MsgChannel.Reader;
        }

        public async Task WriteToFullTextSearchChannle(string msg)
        {
            try
            {
                await fullTextSearchChannel.Writer.WriteAsync(msg);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex, "WriteToFullTextSearchChannle");
                throw;
            }
        }
    }
}
