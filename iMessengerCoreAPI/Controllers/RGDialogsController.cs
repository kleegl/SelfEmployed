using Microsoft.AspNetCore.Mvc;
using iMessengerCoreAPI.Models;
using iMessengerCoreAPI.Repositories.Interfaces;
using iMessengerCoreAPI.Services.Interfaces;

namespace iMessengerCoreAPI.Controllers
{
    [Produces("application/json")]
    //[Route("[controller][action]")]
    [ApiController]
    public class RGDialogsController : Controller
    {
        private readonly IRGDialogsClientsService _iRGDialogsClientsService;
        private readonly IRGDialogsClientsRepository _iRGDialogsClientsRepository;

        public RGDialogsController(IRGDialogsClientsService iRGDialogsClientsService, IRGDialogsClientsRepository iRGDialogsClientsRepository)
        {
            _iRGDialogsClientsService = iRGDialogsClientsService;
            _iRGDialogsClientsRepository = iRGDialogsClientsRepository;
        }

        [HttpPost]
        public JsonResult GetDialogByIDClientList(List<Guid> idClientList)
        {
            return new JsonResult(_iRGDialogsClientsService.GetDialogByIDClientList(idClientList));
        }


        [HttpGet]
        public JsonResult GetAll()
        {
            return new JsonResult(_iRGDialogsClientsRepository.GetAllObjects());
        }
    }
}
