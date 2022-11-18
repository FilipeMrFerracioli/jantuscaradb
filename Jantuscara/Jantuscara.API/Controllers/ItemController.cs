using Jantuscara.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Jantuscara.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : AppBaseController
    {
        private readonly IItemService _item;

        public ItemController(IServiceProvider serviceProvider, IItemService item) : base(serviceProvider)
        {
            _item = item;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ItemResponseVO>))]
        public IActionResult FindAll()
        {
            return Ok(_item.FindAll());
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ItemResponseVO))]
        public IActionResult FindByID(int id)
        {
            return Ok(_item.FindById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ItemResponseVO))]
        public IActionResult Create([FromBody] ItemVO item)
        {
            var res = _item.Create(item);

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