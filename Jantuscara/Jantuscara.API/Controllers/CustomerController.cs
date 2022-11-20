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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerResponseVO))]
        public IActionResult Create([FromBody] CustomerVO item)
        {
            var res = _customer.Create(item);

            return Ok(res);
        }
    }
}