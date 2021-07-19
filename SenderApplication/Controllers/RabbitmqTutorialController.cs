using System;
using System.Threading.Tasks;
using CommonWork;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace SenderApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitmqTutorialController : ControllerBase
    {
        private readonly IBus _bus;
        private readonly IRequestClient<BalanceUpdate> _client;

        public RabbitmqTutorialController(IBus bus , IRequestClient<BalanceUpdate> client)
        {
            _bus = bus;
            _client = client;
        }
        // command send part 

        [HttpPost("send-tutorial")]
        public async Task<IActionResult> Test1()
        {
            var product = new Product()
            {
                Name = "computer",
                Price = 500
            };

            var url = new Uri("rabbitmq://localhost/send-tutorial");

            var endpoint = await _bus.GetSendEndpoint(url);
            await endpoint.Send(product);

            return Ok("hello command send tutorial");
        }

        [HttpPost("publish-tutorial")]
        public async Task<IActionResult> Test2()
        {
            await _bus.Publish(new Person()
            {
                Name = "sumon",
                Email = "sumon@r-cis.com"
            });

            return Ok("publsh tutorial part done");
        }

        [HttpPost("reqres-tutorial")]
        public async Task<IActionResult> Test3()
        {
            var requestData = new BalanceUpdate()
            {
                TypeOfInstruction = "minusAmount",
                Amount = 50
            };


            var request =  _client.Create(requestData);
            var response = await request.GetResponse<NowBalance>();

            return Ok(response);

        }
    }
}