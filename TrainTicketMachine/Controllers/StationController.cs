using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using TrainTicketMachine.Bll.Interfaces;
using TrainTicketMachine.Entities;

namespace TrainTicketMachine.Controllers
{
    //[Authorize]
    public class StationsController : ApiController
    {
        private readonly IStationFinderBll _stationFinderBll;

        public StationsController(IStationFinderBll stationFinderBll)
        {
            _stationFinderBll = stationFinderBll;
        }

        // GET api/values
        public async Task<StationSearchResult> Get(string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                filter=" ";
            }
            filter = filter.Trim('"');
            var stations = await _stationFinderBll.GetAllStartingWith(filter);

            var nextPossibleChars = stations
                .Where(station => station.Length > filter.Length)
                .Select(station => station[filter.Length]).Distinct();

            return new StationSearchResult(nextPossibleChars, stations.OrderBy(x=>x));
        }
    }
}
