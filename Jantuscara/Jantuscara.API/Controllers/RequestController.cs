using Jantuscara.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Jantuscara.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequestController : AppBaseController
    {
        private readonly IRequestService _request;

        public RequestController(IServiceProvider serviceProvider, IRequestService request) : base(serviceProvider)
        {
            _request = request;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RequestResponseVO))]
        public IActionResult FindById(int id)
        {
            return Ok(_request.FindById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RequestResponseVO))]
        public IActionResult Create([FromBody] RequestVO item)
        {
            var res = _request.Create(item);

            return Ok(res);
        }

        [HttpPost]
        [Route("set-discount/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult SetDiscount(int id, [FromBody] int value)
        {
            var res = _request.SetDiscount(id, value);

            return Ok(res);
        }

        [HttpPost]
        [Route("pay-tip/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult PayTip(int id)
        {
            var res = _request.PayTip(id);

            return Ok(res);
        }

        [HttpPost]
        [Route("calculate-amount/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult CalculateAmount(int id)
        {
            var res = _request.CalculateAmount(id);

            return Ok(res);
        }

        [HttpPost]
        [Route("update-status/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateStatus(int id, [FromBody] OrderStatus status)
        {
            var res = _request.UpdateStatus(id, status);

            return Ok(res);
        }
    }
}