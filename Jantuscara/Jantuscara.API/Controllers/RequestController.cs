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

        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<RequestResponseVO>))]
        //public IActionResult FindAll()
        //{
        //    return Ok(_request.FindAll());
        //}

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

        //[HttpPut]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ItemResponseVO))]
        //public IActionResult Update([FromBody] AddressUpdateVO address)
        //{
        //    var res = _address.Update(address);

        //    return Ok(res);
        //}

        //[HttpPut]
        //[Route("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddressResponseVO))]
        //public IActionResult EnableOrUpdate(int id)
        //{
        //    var res = _address.EnableOrDisable(id);

        //    return Ok(res);
        //}
    }
}