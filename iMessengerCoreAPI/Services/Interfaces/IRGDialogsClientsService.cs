using iMessengerCoreAPI.Models.Implementations;

namespace iMessengerCoreAPI.Services.Interfaces
{
    public interface IRGDialogsClientsService
    {
        public List<RGDialogsClients> GetAllObjects();

        public Guid GetDialogByIDClientList(List<Guid> iDClients);
    }
}
