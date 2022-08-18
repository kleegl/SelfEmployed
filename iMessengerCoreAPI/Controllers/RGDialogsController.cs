using Microsoft.AspNetCore.Mvc;
using iMessengerCoreAPI.Models;
using iMessengerCoreAPI.Repositories.Interfaces;
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
        private readonly IRGDialogsClientsRepository _iRGDialogsClientsRepository;

        public RGDialogsController(IRGDialogsClientsService iRGDialogsClientsService, IRGDialogsClientsRepository iRGDialogsClientsRepository)
        {
            _iRGDialogsClientsService = iRGDialogsClientsService;
            _iRGDialogsClientsRepository = iRGDialogsClientsRepository;
        }

        [HttpPost("dialog-id-by-client-list")]
        public JsonResult GetDialogByIDClientList(List<Guid> idClientList)
        {
            return new JsonResult(_iRGDialogsClientsService.GetDialogByIDClientList(idClientList));
        }


        [HttpGet("rg-dialogs-clients-all")]
        public JsonResult GetAll()
        {
            return new JsonResult(_iRGDialogsClientsRepository.GetAllObjects());
        }
    }
}
