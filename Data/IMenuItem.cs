using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// The IMenuItem interface.
    /// </summary>
    public interface IMenuItem
    {
        /// <summary>
        /// The name of the item.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The description of the item.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// The price of the item.
        /// </summary>
        public decimal Price { get; }

        /// <summary>
        /// How many calories the item is.
        /// </summary>
        public uint Calories { get; }

        /// <summary>
        /// Any special instructions for the item.
        /// </summary>
        public IEnumerable<string> SpecialInstructions { get; }
    }
}
