using System;
using System.Collections.Generic;
using System.Linq;

namespace TrainTicketMachine.Entities
{
    /// <summary>
    /// This business entity encapsulate station search result.
    /// </summary>
    public class StationSearchResult
    {
        public StationSearchResult(IEnumerable<char> nextPossibleCharacters, IEnumerable<string> stations)
        {
            NextPossibleCharacters = nextPossibleCharacters ?? new char[0];
            Stations = stations ?? new string[0];
        }

        public IEnumerable<char> NextPossibleCharacters { get; private set; }

        public IEnumerable<string> Stations { get; private set; }
    }
}