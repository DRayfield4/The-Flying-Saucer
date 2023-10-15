using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Details for the SaucerFuel drink
    /// </summary>
    public class SaucerFuel : Drink
    {
        /// <summary>
        /// Private backing field for Size
        /// </summary>
        private ServingSize _size = ServingSize.Small;

        /// <summary>
        /// Private backing field for Decaf
        /// </summary>
        private bool _decaf = false;

        /// <summary>
        /// Private backing field for Cream
        /// </summary>
        private bool _cream = false;

        /// <summary>
        /// The name of the SaucerFuel instance
        /// </summary>
        public override string Name
        {
            get
            {
                switch(Decaf)
                {
                    case true:
                        return "Decaf Saucer Fuel";
                    default:
                        return "Saucer Fuel";
                }
            }
        }

        /// <summary>
        /// The description of the SaucerFuel instance
        /// </summary>
        public override string Description { get; } = "A steaming cup of coffee.";

        /// <summary>
        /// The size of the SaucerFuel
        /// </summary>
        public override ServingSize Size
        {
            get
            {
                return _size;
            }
            set
            {
                if(_size != value )
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
        /// If the SaucerFuel is decaf
        /// </summary>
        public bool Decaf
        {
            get
            {
                return _decaf;
            }
            set
            {
                if(_decaf != value)
                {
                    _decaf = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        /// <summary>
        /// If the SaucerFuel comes with cream
        /// </summary>
        public bool Cream
        {
            get
            {
                return _cream;
            }
            set
            {
                if(_cream != value)
                {
                    _cream = value;
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(SpecialInstructions));
                }
            }
        }

        /// <summary>
        /// The price of the SaucerFuel
        /// </summary>
        public override decimal Price
        {
            get
            {
                switch (Size)
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
        /// The calories of the SaucerFuel
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint calories = 0u;
                switch (Size)
                {
                    case ServingSize.Small:
                        calories = 1u;
                        break;
                    case ServingSize.Medium:
                        calories = 2u;
                        break;
                    case ServingSize.Large:
                        calories = 3u;
                        break;
                    default:
                        throw new InvalidOperationException("Please choose a small, medium, or large size.");
                }
                if (Cream) calories += 29u;
                return calories;
            }
        }

        /// <summary>
        /// Special instructions for the SaucerFuel
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (Cream) instructions.Add("With Cream");
                return instructions;
            }
        }
    }
}
