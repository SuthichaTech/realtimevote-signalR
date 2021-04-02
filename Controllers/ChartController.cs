using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using server.Hubs;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChartController : ControllerBase
    {
        private IHubContext<DataHubs> _hubContext;

        public ChartController(IHubContext<DataHubs> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet("send/graph1")]
        public IActionResult GetTest()
        {
            var result = _hubContext.Clients.All.SendAsync("chartStation1", 5);
            return Ok(new {
                Status = "Send to Graph 1 Completed",
            });
        }

        [HttpGet("send/graph2")]
        public IActionResult GetTest2()
        {
            var result = _hubContext.Clients.All.SendAsync("chartStation2", 5);
            return Ok(new {
                Status = "Send to Graph 2 Completed",
            });
        }

    }
}