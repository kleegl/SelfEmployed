using iMessengerCoreAPI.Models.Implementations;
using iMessengerCoreAPI.Models.Interfaces;
using iMessengerCoreAPI.Repositories.Interfaces;

namespace iMessengerCoreAPI.Repositories.Implementations
{
    public class RGDialogsClientsRepository : IRGDialogsClientsRepository
    {
        private readonly List<RGDialogsClients> _rGDialogsClientsList = new List<RGDialogsClients>();
        public RGDialogsClientsRepository(IRGDialogsClients iRGDialogsClients)
        {
             foreach(var initObject in iRGDialogsClients.Init())
            {
                _rGDialogsClientsList.Add(initObject);
            }
        }

        public List<RGDialogsClients> GetAllObjects()
        {
            return _rGDialogsClientsList;
        }
    }
}
