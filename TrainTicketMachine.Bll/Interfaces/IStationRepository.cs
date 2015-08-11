using System.Collections.Generic;

namespace TrainTicketMachine.Bll.Interfaces
{
    public interface IStationRepository
    {
        IEnumerable<string> AllStations();
    }
}