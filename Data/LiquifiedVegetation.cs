using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Details for the LiquifiedVegetation drink
    /// </summary>
    public class LiquifiedVegetation : Drink
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
        /// The name of the Liquified Vegetation instance
        /// </summary>
        public override string Name { get; } = "Liquified Vegetation";

        /// <summary>
        /// The description of the Liquified Vegetation instance
        /// </summary>
        public override string Description { get; } = "A cold glass of blended vegetable juice.";

        /// <summary>
        /// The size of the Liquified Vegetation
        /// </summary>
        public override ServingSize Size
        {
            get
            {
                return _size;
            }
            set
            {
                if(_size != value)
                {
                    _size = value;
                    //OnPropertyChanged(nameof(Size));
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(Calories));
                }
                else
                {
                    _size = ServingSize.Small;
                    //OnPropertyChanged(nameof(Size));
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(Calories));
                }
            }
        }

        /// <summary>
        /// If the Liquified Vegetation has ice
        /// </summary>
        public bool Ice
        {
            get
            {
                return _ice;
            }
            set
            {
                if(_ice != value)
                {
                    _ice = value;
                    OnPropertyChanged(nameof(SpecialInstructions));
                }
            }
        }

        /// <summary>
        /// The price of the Liquified Vegetation
        /// </summary>
        public override decimal Price
        {
            get
            {
                switch(Size)
                {
                    case ServingSize.Small:
                        return 1.00m;
                    case ServingSize.Medium:
                        return 1.50m;
                    case ServingSize.Large:
                        return 2.00m;
                    default:
                        throw new InvalidOperationException("Please choose a small, medium, or large size.");
                }
            }
        }

        /// <summary>
        /// The calories of the Liquified Vegetation
        /// </summary>
        public override uint Calories
        {
            get
            {
                switch(Size)
                {
                    case ServingSize.Small:
                        return 72u;
                    case ServingSize.Medium:
                        return 144u;
                    case ServingSize.Large:
                        return 216u;
                    default:
                        throw new InvalidOperationException("Please choose a small, medium, or large size.");
                }
            }
        }

        /// <summary>
        /// Special instructions for the Liquified Vegetation
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
