using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Details for the Crashed Saucer dish
    /// </summary>
    public class CrashedSaucer : Entree
    {
        /// <summary>
        /// Private backing field for Syrup
        /// </summary>
        private bool _syrup = true;

        /// <summary>
        /// Private backing field for Butter
        /// </summary>
        private bool _butter = true;

        /// <summary>
        /// The name of the Crashed Saucer instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public override string Name { get; } = "Crashed Saucer";

        /// <summary>
        /// The description of the Crashed Saucer instance
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public override string Description => "A stack of crispy french toast smothered in syrup and topped with a pat of butter.";

        /// <summary>
        /// The private field for the StackSize property
        /// </summary>
        private uint _stackSize = 2;

        /// <summary>
        /// The number of slices in this instance of a Crashed Saucer
        /// </summary>
        /// <remarks>
        /// Note the set limits the stack size to a maximum of 6 slices
        /// </remarks>
        public uint StackSize
        {
            get
            {
                return _stackSize;
            }
            set
            {
                if (value <= 6 && value != 2)
                {
                    _stackSize = value;
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(SpecialInstructions));
                }
                else if(value == 2)
                {
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(Calories));
                }
                else
                {
                    _stackSize = 6;
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(SpecialInstructions));
                }
            }
        }

        /// <summary>
        /// If the Crashed Saucer instance is served with maple syrup
        /// </summary>
        /// <remarks>
        /// Here we have an autoproperty with both getter and setter, 
        /// and a default value
        /// </remarks>
        public bool Syrup
        {
            get
            {
                return _syrup;
            }
            set
            {
                if (_syrup != value)
                {
                    _syrup = value;
                    OnPropertyChanged(nameof(SpecialInstructions));
                }
                else
                {
                    _syrup = value;
                    OnPropertyChanged(nameof(Calories));
                }
            }
        }

        /// <summary>
        /// If the Crashed Saucer instance is served with butter
        /// </summary>
        /// <remarks>
        /// Here we have an autoproperty with both getter and setter, 
        /// and a default value
        /// </remarks>
        public bool Butter
        {
            get
            {
                return _butter;
            }
            set
            {
                if (_butter != value)
                {
                    _butter = value;
                    OnPropertyChanged(nameof(SpecialInstructions));
                }
                else
                {
                    _butter = value;
                    OnPropertyChanged(nameof(Calories));
                }
            }
        }

        /// <summary>
        /// The price of the Crashed Saucer instance
        /// </summary>
        public override decimal Price
        {
            get
            {
                if (StackSize > 2)
                {
                    return 6.45m + (((decimal)StackSize - 2) * 1.5m);
                }
                else
                {
                    return 6.45m;
                }
            }
        }

        /// <summary>
        /// The calories of the Crashed Saucer instance
        /// </summary>
        /// <remarks>
        /// This is a get-only property whose value is derived from the other properties of the class.
        /// </remarks>
        public override uint Calories
        {
            get
            {
                uint calories = 149u * StackSize;
                if (Syrup) calories += 52u;
                if (Butter) calories += 35u;
                return calories;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this Crashed Saucer
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (StackSize != 2) instructions.Add($"{StackSize} Slices");
                if (!Syrup) instructions.Add("Hold syrup");
                if (!Butter) instructions.Add("Hold butter");
                return instructions;
            }
        }
    }
}
