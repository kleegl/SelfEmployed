using iMessengerCoreAPI.Services.Interfaces;
using iMessengerCoreAPI.Repositories.Implementations;
using iMessengerCoreAPI.Repositories.Interfaces;
using iMessengerCoreAPI.Models.Implementations;

namespace iMessengerCoreAPI.Services.Implementations
{
    public class RGDialogsClientsService : IRGDialogsClientsService
    {
        private readonly IRGDialogsClientsRepository _iRGDialogsClientsRepository;
        public RGDialogsClientsService(IRGDialogsClientsRepository iRGDialogsClientsRepository)
        {
            _iRGDialogsClientsRepository = iRGDialogsClientsRepository;
        }

        public List<RGDialogsClients> GetAllObjects()
        {
            try
            {
                return _iRGDialogsClientsRepository.GetAllObjects();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public Guid GetDialogByIDClientList(List<Guid> idClientList)
        {
            try
            {
                List<Guid> findDialogList = new();
                Guid resultIdDialog = Guid.Empty;
                foreach (Guid idClient in idClientList)
                {
                    foreach (RGDialogsClients rGDialogClient in _iRGDialogsClientsRepository.GetAllObjects())
                    {
                        if (idClient == idClientList[0])
                        {
                            if (Guid.Equals(idClient, rGDialogClient.IDClient))
                            {
                                findDialogList.Add(rGDialogClient.IDRGDialog);
                                resultIdDialog = rGDialogClient.IDRGDialog;
                            }
                        }
                        else
                        {
                            List<Guid> tempFindDialogList = new List<Guid>();
                            if (Guid.Equals(idClient, rGDialogClient.IDClient))
                            {
                                tempFindDialogList.Add(rGDialogClient.IDRGDialog);
                            }
                            if (findDialogList.Count != 0 && tempFindDialogList.Count != 0)
                            {
                                foreach (Guid guidDialog in findDialogList)
                                {
                                    foreach (Guid tempGuidDialog in tempFindDialogList)
                                    {
                                        if (Guid.Equals(guidDialog, tempGuidDialog))
                                            resultIdDialog = guidDialog;
                                    }
                                }
                            }
                        }
                    }
                }
                return resultIdDialog;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Guid.Empty;
        }
    }
}
