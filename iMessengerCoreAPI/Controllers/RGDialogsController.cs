using Microsoft.AspNetCore.Mvc;
using iMessengerCoreAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace iMessengerCoreAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class RGDialogsController : Controller
    {
        private readonly IRGDialogsClientsService _iRGDialogsClientsService;

        public RGDialogsController(IRGDialogsClientsService iRGDialogsClientsService)
        {
            _iRGDialogsClientsService = iRGDialogsClientsService;
        }

        [HttpPost("dialog-id-by-client-list")]
        public JsonResult GetDialogByIDClientList(List<Guid> idClientList)
        {
            return new JsonResult(_iRGDialogsClientsService.GetDialogByIDClientList(idClientList));
        }


        [HttpGet("rg-dialogs-clients-all")]
        public JsonResult GetAll()
        {
            return new JsonResult(_iRGDialogsClientsService.GetAllObjects());
        }
    }
}
