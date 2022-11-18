using Microsoft.AspNetCore.Mvc;

namespace Jantuscara.API.Controllers
{
    public class AppBaseController : ControllerBase
    {
        protected readonly IServiceProvider _serviceProvider;

        public AppBaseController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }
}