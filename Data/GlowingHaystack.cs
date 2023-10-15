using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Details for the Glowing Haystack dish
    /// </summary>
    public class GlowingHaystack : Side
    {
        /// <summary>
        /// Private backing field for GreenChileSauce
        /// </summary>
        private bool _greenChileSauce = true;

        /// <summary>
        /// Private backing field for SourCream
        /// </summary>
        private bool _sourCream = true;

        /// <summary>
        /// Private backing field for Tomatoes
        /// </summary>
        private bool _tomatoes = true;

        /// <summary>
        /// The name of the Glowing Haystack instance
        /// </summary>
        public override string Name { get; } = "Glowing Haystack";

        /// <summary>
        /// The description of the Glowing Haystack instance
        /// </summary>
        public override string Description { get; } = "Hash browns smothered in green chile sauce, sour cream, and topped with tomatoes.";

        /// <summary>
        /// If the Glowing Haystack is served with green chile sauce
        /// </summary>
        public bool GreenChileSauce
        {
            get
            {
                return _greenChileSauce;
            }
            set
            {
                if(_greenChileSauce != value)
                {
                    _greenChileSauce = value;
                    OnPropertyChanged(nameof(SpecialInstructions));
                }
                else
                {
                    _greenChileSauce = value;
                    OnPropertyChanged(nameof(Calories));
                }
            }
        }

        /// <summary>
        /// If the Glowing Haystack has sour cream
        /// </summary>
        public bool SourCream
        {
            get
            {
                return _sourCream;
            }
            set
            {
                if (_sourCream != value)
                {
                    _sourCream = value;
                    OnPropertyChanged(nameof(SpecialInstructions));
                }
                else
                {
                    _sourCream = value;
                    OnPropertyChanged(nameof(Calories));
                }
            }
        }

        /// <summary>
        /// If the Glowing Haystack has Tomatoes
        /// </summary>
        public bool Tomatoes
        {
            get
            {
                return _tomatoes;
            }
            set
            {
                if (_tomatoes != value)
                {
                    _tomatoes = value;
                    OnPropertyChanged(nameof(SpecialInstructions));
                }
                else
                {
                    _tomatoes = value;
                    OnPropertyChanged(nameof(Calories));
                }
            }
        }

        /// <summary>
        /// The price of the Glowing Haystack
        /// </summary>
        public override decimal Price { get; } = 2.00m;

        /// <summary>
        /// The calories of the Glowing Haystack
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint calories = 470u;
                if (GreenChileSauce) calories += 15u;
                if (SourCream) calories += 23u;
                if (Tomatoes) calories += 22u;
                return calories;
            }
        }

        /// <summary>
        /// Special instructions for the preperation of the Glowing Haystack
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (!GreenChileSauce) instructions.Add("Hold Green Chile Sauce");
                if (!SourCream) instructions.Add("Hold Sour Cream");
                if (!Tomatoes) instructions.Add("Hold Tomatoes");
                return instructions;
            }
        }
    }
}
