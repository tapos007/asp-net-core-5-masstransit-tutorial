using System.Threading.Tasks;
using CommonWork;
using MassTransit;

namespace ReceiverApplication
{
    public class SenderTutorial : IConsumer<Product>
    {
        public async Task Consume(ConsumeContext<Product> context)
        {
            var product = context.Message;
        }
    }
}