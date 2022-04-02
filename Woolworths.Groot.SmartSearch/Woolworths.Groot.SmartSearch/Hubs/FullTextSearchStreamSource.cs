using System.Reactive.Subjects;
using System.Threading.Channels;

namespace Woolworths.Groot.SmartSearch.Hubs
{
    public class FullTextSearchStreamSource
    {
        //public Channel<string> MsgChannel { get; } = Channel.CreateUnbounded<string>();

        private event EventHandler<string> writeMessage;

        public Subject<string> bump = new();

        public IObservable<string> StreamMesage()
        {
            return bump;
        }

        public ChannelReader<string> CreateChannelForClient()
        {
            var channel = Channel.CreateUnbounded<string>();
            writeMessage += (object? sender, string e) =>
            {
                channel.Writer.WriteAsync(e);
            };
            return channel.Reader;
        }

        
        public Task WriteMsg(string msg)
        {
            //MsgChannel.Writer.WriteAsync(msg);
            
            writeMessage.Invoke(this, msg);

            return Task.CompletedTask;

        }
    }
}
