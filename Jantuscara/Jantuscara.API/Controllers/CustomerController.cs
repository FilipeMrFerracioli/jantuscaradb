using Jantuscara.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Jantuscara.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : AppBaseController
    {
        private readonly ICustomerService _customer;

        public CustomerController(IServiceProvider serviceProvider, ICustomerService customer) : base(serviceProvider)
        {
            _customer = customer;
        }

        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<RequestResponseVO>))]
        //public IActionResult FindAll()
        //{
        //    return Ok(_request.FindAll());
        //}

        //[HttpGet]
        //[Route("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RequestResponseVO))]
        //public IActionResult FindById(int id)
        //{
        //    return Ok(_request.FindById(id));
        //}

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerResponseVO))]
        public IActionResult Create([FromBody] CustomerVO item)
        {
            var res = _customer.Create(item);

            return Ok(res);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerResponseVO))]
        public IActionResult Update([FromBody] CustomerVO item)
        {
            var res = _customer.Update(item);

            return Ok(res);
        }

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