using System.Collections.Generic;
using System.Threading.Tasks;
using TrainTicketMachine.Bll.DataStructures;
using TrainTicketMachine.Bll.Interfaces;

namespace TrainTicketMachine.Bll
{
    public class StationFinderBll : IStationFinderBll
    {
        private readonly IPrefixTree _prefixTree;

        public StationFinderBll(IStationRepository stationRepository,IPrefixTree prefixTree)
        {
            _prefixTree = prefixTree;
            _prefixTree.Add(stationRepository.AllStations());
        }

        /// <summary>
        /// Gets all stations starting with the parameter value.
        /// </summary>
        /// <param name="name">The station name filter.</param>
        /// <returns>
        /// The list of stations.
        /// </returns>
        public async Task<IEnumerable<string>> GetAllStartingWith(string name)
        {
            return await _prefixTree.FindAsync(name);
        }
    }
}
