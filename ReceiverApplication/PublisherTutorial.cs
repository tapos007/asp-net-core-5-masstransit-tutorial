using System.Threading.Tasks;
using CommonWork;
using MassTransit;

namespace ReceiverApplication
{
    public class PublisherTutorial : IConsumer<Person>
    {
        public async Task Consume(ConsumeContext<Person> context)
        {
            var info = context.Message;
        }
    }
}