using System.Collections.Generic;
using TrainTicketMachine.Bll.Interfaces;

namespace TrainTicketMachine.Bll.Repository
{
   public class StationRepository : IStationRepository
    {
        public IEnumerable<string> AllStations()
        {
            return new List<string>() { "DARTMOUTH", "TOWER HILL", "DARTFORD", "LIVERPOOL LIME STREET", "LIVERPOOL STREET", "PADDINGTON", "EUSTON", "KINGS CROSS", "LONDON BRIDGE", "VICTORIA" };
        }
    }
}