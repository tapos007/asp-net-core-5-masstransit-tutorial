using System.Threading.Tasks;
using CommonWork;
using MassTransit;

namespace ReceiverApplication
{
    public class RequestResponseTutorial : IConsumer<BalanceUpdate>
    {
        
        public async Task Consume(ConsumeContext<BalanceUpdate> context)
        {
            var data = context.Message;


            var nowBalance = new NowBalance()
            {
                Balance = 1000
            };

            await context.RespondAsync<NowBalance>(nowBalance);
        }
    }
}