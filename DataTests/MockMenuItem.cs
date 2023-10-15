using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// A mock menu item to test the Order class
    /// </summary>
    public class MockMenuItem : IMenuItem
    {
        /// <summary>
        /// Name of item
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of item
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Price of item
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Calories of item
        /// </summary>
        public uint Calories { get; set; }

        /// <summary>
        /// Special Instructions for item
        /// </summary>
        public IEnumerable<string> SpecialInstructions { get; set; }
    }
}
