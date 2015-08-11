using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrainTicketMachine.Bll.DataStructures
{
    public interface IPrefixTree
    {
        /// <summary>
        /// Finds the specified prefix.
        /// </summary>
        /// <param name="prefix">The prefix.</param>
        /// <returns></returns>
        Task<IEnumerable<string>> FindAsync(string prefix);

        /// <summary>
        /// Adds the specified terms into the Tree.
        /// </summary>
        /// <param name="items">The terms.</param>
        void Add(IEnumerable<string> items);
    }
}