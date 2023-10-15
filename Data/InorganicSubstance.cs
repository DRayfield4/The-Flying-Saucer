using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Details for the InorganicSubstance drink
    /// </summary>
    public class InorganicSubstance : Drink
    {
        /// <summary>
        /// Private backing field for Size
        /// </summary>
        private ServingSize _size = ServingSize.Small;

        /// <summary>
        /// Private backing field for Ice
        /// </summary>
        private bool _ice = true;

        /// <summary>
        /// The name of the Inorganic Substance instance
        /// </summary>
        public override string Name { get; } = "Inorganic Substance";

        /// <summary>
        /// The description of the Inorganic Substance instance
        /// </summary>
        public override string Description { get; } = "A cold glass of ice water.";

        /// <summary>
        /// The size of the InorganicSubstance
        /// </summary>
        public override ServingSize Size
        {
            get
            {
                return _size;
            }
            set
            {
                if (_size != value)
                {
                    _size = value;
                }
            }
        }

        /// <summary>
        /// If the Inorganic Substance has ice
        /// </summary>
        public bool Ice
        {
            get
            {
                return _ice;
            }
            set
            {
                if (_ice != value)
                {
                    _ice = value;
                    OnPropertyChanged(nameof(SpecialInstructions));
                }
            }
        }

        /// <summary>
        /// The price of the Inorganic Substance
        /// </summary>
        public override decimal Price { get; } = 0;

        /// <summary>
        /// The calories of the Inorganic Substance
        /// </summary>
        public override uint Calories { get; } = 0;

        /// <summary>
        /// Special instructions for the Inorganic Substance
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (!Ice) instructions.Add("No Ice");
                return instructions;
            }
        }
    }
}
