using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Details for the Taken Bacon dish
    /// </summary>
    public class TakenBacon : Side
    {
        /// <summary>
        /// The name of the Taken Bacon instance
        /// </summary>
        public override string Name { get; } = "Taken Bacon";

        /// <summary>
        /// The description of the Taken Bacon instance
        /// </summary>
        public override string Description { get; } = "Crispy strips of bacon.";

        /// <summary>
        /// The private backing field for the Count property
        /// </summary>
        private uint _count = 2;

        /// <summary>
        /// How many slices of bacon the Taken Bacon gets
        /// </summary>
        public uint Count
        {
            get
            {
                return _count;
            }
            set
            {
                if(value >= 1 && value <= 6 && value != 2)
                {
                    _count = value;
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(SpecialInstructions));
                }
                else if(value < 1)
                {
                    _count = 2;
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(Calories));
                }
                else if(value == 2)
                {
                    _count = 2;
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(Calories));
                }
                else
                {
                    _count = 6;
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(SpecialInstructions));
                }
            }
        }

        /// <summary>
        /// The price of the Taken Bacon
        /// </summary>
        public override decimal Price
        {
            get
            {
                return (decimal)Count;
            }
        }

        /// <summary>
        /// The calories of the Taken Bacon
        /// </summary>
        public override uint Calories
        {
            get
            {
                return (uint)Count * 43u;
            }
        }

        /// <summary>
        /// Special instructions for the preperation of the Taken Bacon
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (Count != 2) instructions.Add($"{Count} strips");
                return instructions;
            }
        }
    }
}
