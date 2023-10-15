using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Details for the Crop Circle dish
    /// </summary>
    public class CropCircle : Side
    {
        /// <summary>
        /// Private backing field for Berries
        /// </summary>
        private bool _berries = true;

        /// <summary>
        /// The name of the Crop Circle instance
        /// </summary>
        public override string Name { get; } = "Crop Circle";

        /// <summary>
        /// The description of the Crop Circle instance
        /// </summary>
        public override string Description { get; } = "Oatmeal topped with mixed berries.";

        /// <summary>
        /// If the Crop Circle has berries
        /// </summary>
        public bool Berries
        {
            get
            {
                return _berries;
            }
            set
            {
                if (_berries != value)
                {
                    _berries = value;
                    OnPropertyChanged(nameof(SpecialInstructions));
                }
                else
                {
                    _berries = value;
                    OnPropertyChanged(nameof(Calories));
                }
            }
        }

        /// <summary>
        /// The price of the Crop Circle
        /// </summary>
        public override decimal Price { get; } = 2.00m;

        /// <summary>
        /// The calories of the Crop Circle
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint calories = 158u;
                if (Berries) calories += 89u;
                return calories;
            }
        }

        /// <summary>
        /// Special instructions for the preperation of the Crop Circle
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (!Berries) instructions.Add("Hold Berries");
                return instructions;
            }
        }
    }
}
