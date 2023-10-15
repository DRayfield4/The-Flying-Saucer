using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Details for the Livestock Mutilation dish
    /// </summary>
    public class LivestockMutilation : Entree
    {
        /// <summary>
        /// Private backing field for Gravy
        /// </summary>
        private bool _gravy = true;

        /// <summary>
        /// The name of the LivestockMutilation instance
        /// </summary>
        /// /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public override string Name { get; } = "Livestock Mutilation";

        /// <summary>
        /// The description of the LivestockMutilation instance
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public override string Description => "A hearty serving of biscuits, smothered in sausage-laden gravy.";

        /// <summary>
        /// The private backing field for the Biscuits property.
        /// </summary>
        private uint _numBiscuits = 3;

        /// <summary>
        /// The number of biscuits in this LivestockMutilation
        /// </summary>
        /// /// <remarks>
        /// Note the set limits the biscuits to a maximum of 8
        /// </remarks>
        public uint Biscuits
        {
            get
            {
                return _numBiscuits;
            }
            set
            {
                if (value <= 8 && value != 3)
                {
                    _numBiscuits = value;
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(SpecialInstructions));
                }
                else if(value == 3)
                {
                    _numBiscuits = 3;
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(Calories));
                }
                else
                {
                    _numBiscuits = 8;
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(SpecialInstructions));
                }
            }
        }

        /// <summary>
        /// If the LivestockMutilation is served with gravy
        /// </summary>
        public bool Gravy
        {
            get
            {
                return _gravy;
            }
            set
            {
                if(_gravy != value)
                {
                    _gravy = value;
                    OnPropertyChanged(nameof(SpecialInstructions));
                }
                else
                {
                    _gravy = true;
                    OnPropertyChanged(nameof(Calories));
                }
            }
        }

        /// <summary>
        /// The price of the LivestockMutilation instance
        /// </summary>
        public override decimal Price
        {
            get
            {
                if (Biscuits > 3)
                {
                    return 7.25m + (((decimal)Biscuits - 3) * 1);
                }
                else
                {
                    return 7.25m;
                }
            }
        }

        /// <summary>
        /// The calories of the LivestockMutilation
        /// </summary>
        /// <remarks>
        /// This is a get-only property whose value is derived from the other properties of the class.
        /// </remarks>
        public override uint Calories
        {
            get
            {
                uint calories = 49 * Biscuits;
                if (Gravy) calories += 140u;
                return calories;
            }
        }

        /// <summary>
        /// Special instructions for the preperation of this LivestockMutilation
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (Biscuits != 3) instructions.Add($"{Biscuits} biscuits");
                if (!Gravy) instructions.Add("Hold gravy");
                return instructions;
            }
        }
    }
}