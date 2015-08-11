using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrainTicketMachine.Bll.Interfaces
{
    public interface IStationFinderBll
    {
        /// <summary>
        /// Gets all stations started with the name parameter value.
        /// </summary>
        /// <param name="name">The station name filter.</param>
        /// <returns>The list of stations.</returns>
       Task<IEnumerable<string>> GetAllStartingWith(string name);
    }
}