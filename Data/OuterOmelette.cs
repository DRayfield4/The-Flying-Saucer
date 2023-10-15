using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Details for the Outer Omelette dish
    /// </summary>
    public class OuterOmelette : Entree
    {
        /// <summary>
        /// Private backing field for Cheddar Cheese
        /// </summary>
        private bool _cheddarCheese = true;

        /// <summary>
        /// Private backing field for Peppers
        /// </summary>
        private bool _peppers = true;

        /// <summary>
        /// Private backing field for Mushrooms
        /// </summary>
        private bool _mushrooms = true;

        /// <summary>
        /// Private backing field for Tomatoes
        /// </summary>
        private bool _tomatoes = true;

        /// <summary>
        /// Private backing field for Onions
        /// </summary>
        private bool _onions = true;

        /// <summary>
        /// The name of the Outer Omelette instance
        /// </summary>
        public override string Name { get; } = "Outer Omelette";

        /// <summary>
        /// The description of the Outer Omelette instance
        /// </summary>
        public override string Description { get; } = "A fully loaded Omelette.";

        /// <summary>
        /// If the Outer Omelette is served with cheddar cheese
        /// </summary>
        public bool CheddarCheese
        {
            get
            {
                return _cheddarCheese;
            }
            set
            {
                if( _cheddarCheese != value )
                {
                    _cheddarCheese = value;
                    OnPropertyChanged(nameof(SpecialInstructions));
                }
                else
                {
                    _cheddarCheese = value;
                    OnPropertyChanged(nameof(Calories));
                }
            }
        }

        /// <summary>
        /// If the Outer Omelette has peppers
        /// </summary>
        public bool Peppers
        {
            get
            {
                return _peppers;
            }
            set
            {
                if (_peppers != value)
                {
                    _peppers = value;
                    OnPropertyChanged(nameof(SpecialInstructions));
                }
                else
                {
                    _peppers = value;
                    OnPropertyChanged(nameof(Calories));
                }
            }
        }

        /// <summary>
        /// If the Outer Omelette has mushrooms
        /// </summary>
        public bool Mushrooms
        {
            get
            {
                return _mushrooms;
            }
            set
            {
                if (_mushrooms != value)
                {
                    _mushrooms = value;
                    OnPropertyChanged(nameof(SpecialInstructions));
                }
                else
                {
                    _mushrooms = value;
                    OnPropertyChanged(nameof(Calories));
                }
            }
        }

        /// <summary>
        /// If the Outer Omelette has tomatoes
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
        /// If the Outer Omelette has onions
        /// </summary>
        public bool Onions
        {
            get
            {
                return _onions;
            }
            set
            {
                if (_onions != value)
                {
                    _onions = value;
                    OnPropertyChanged(nameof(SpecialInstructions));
                }
                else
                {
                    _onions = value;
                    OnPropertyChanged(nameof(Calories));
                }
            }
        }

        /// <summary>
        /// The price of the Outer Omelette
        /// </summary>
        public override decimal Price { get; } = 7.45m;

        /// <summary>
        /// The calories of the Outer Omelette
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint calories = 94u;
                if (CheddarCheese) calories += 113u;
                if (Peppers) calories += 24u;
                if (Mushrooms) calories += 4u;
                if (Tomatoes) calories += 22u;
                if (Onions) calories += 22u;
                return calories;
            }
        }

        /// <summary>
        /// Special instructions for the preperation of the Outer Omelette
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (!CheddarCheese) instructions.Add("Hold Cheddar Cheese");
                if (!Peppers) instructions.Add("Hold Peppers");
                if (!Mushrooms) instructions.Add("Hold Mushrooms");
                if (!Tomatoes) instructions.Add("Hold Tomatoes");
                if (!Onions) instructions.Add("Hold Onions");
                return instructions;
            }
        }
    }
}
