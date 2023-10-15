using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Details for the You're Toast dish
    /// </summary>
    public class YoureToast : Side
    {
        /// <summary>
        /// The name of the You're Toast instance
        /// </summary>
        public override string Name { get; } = "You're Toast";

        /// <summary>
        /// The description of the You're Toast instance
        /// </summary>
        public override string Description { get; } = "Texas toast.";

        /// <summary>
        /// The private backing field for the Count property
        /// </summary>
        private uint _count = 2;

        /// <summary>
        /// How many eggs the You're Toast gets
        /// </summary>
        public uint Count
        {
            get
            {
                return _count;
            }
            set
            {
                if (value >= 1 && value <= 12 && value != 2)
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
                else if(value == 2)
                {
                    _count = 2;
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(Calories));
                }
                else
                {
                    _count = 12;
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(SpecialInstructions));
                }
            }
        }

        /// <summary>
        /// The price of the You're Toast
        /// </summary>
        public override decimal Price
        {
            get
            {
                return (decimal)Count;
            }
        }

        /// <summary>
        /// The calories of the You're Toast
        /// </summary>
        public override uint Calories
        {
            get
            {
                return (uint)Count * 100u;
            }
        }

        /// <summary>
        /// Special instructions for the preperation of the You're Toast
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (Count != 2) instructions.Add($"{Count} slices");
                return instructions;
            }
        }
    }
}