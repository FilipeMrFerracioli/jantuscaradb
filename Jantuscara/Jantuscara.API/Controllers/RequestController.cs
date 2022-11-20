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
    }
}