using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Details for the Missing Links dish
    /// </summary>
    public class MissingLinks : Side
    {
        /// <summary>
        /// The name of the Missing Links instance
        /// </summary>
        public override string Name { get; } = "Missing Links";

        /// <summary>
        /// The description of the Missing Links instance
        /// </summary>
        public override string Description { get; } = "Sizzling pork sausage links.";

        /// <summary>
        /// The private backing field for the Count property
        /// </summary>
        private uint _count = 2;

        /// <summary>
        /// How many slices of sausage the Missing Links gets
        /// </summary>
        public uint Count
        {
            get
            {
                return _count;
            }
            set
            {
                if (value >= 1 && value <= 8 && value != 2)
                {
                    _count = value;
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(SpecialInstructions));
                }
                else if (value < 1)
                {
                    _count = 2;
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(Calories));
                }
                else if (value == 2)
                {
                    _count = 2;
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(Calories));
                }
                else
                {
                    _count = 8;
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(SpecialInstructions));
                }
            }
        }

        /// <summary>
        /// The price of the Missing Links
        /// </summary>
        public override decimal Price
        {
            get
            {
                return (decimal)Count;
            }
        }

        /// <summary>
        /// The calories of the Missing Links
        /// </summary>
        public override uint Calories
        {
            get
            {
                return (uint)Count * 391u;
            }
        }

        /// <summary>
        /// Special instructions for the preperation of the Missing Links
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (Count != 2) instructions.Add($"{Count} links");
                return instructions;
            }
        }
    }
}
