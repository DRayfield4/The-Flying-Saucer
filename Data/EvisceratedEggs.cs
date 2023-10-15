using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Details for the Eviscerated Eggs dish
    /// </summary>
    public class EvisceratedEggs : Side
    {
        /// <summary>
        /// The name of the Eviscerated Eggs instance
        /// </summary>
        public override string Name { get; } = "Eviscerated Eggs";

        /// <summary>
        /// The description of the Eviscerated Eggs instance
        /// </summary>
        public override string Description { get; } = "Eggs prepared the way you like.";

        /// <summary>
        /// The private backing field for the EggStyle property
        /// </summary>
        private EggStyle _style = EggStyle.OverEasy;

        /// <summary>
        /// The style of egg of the Eviscerated Eggs dish
        /// </summary>
        public EggStyle Style
        {
            get
            {
                return _style;
            }
            set
            {
                if(value != _style)
                {
                    _style = value;
                    OnPropertyChanged(nameof(SpecialInstructions));
                }
                else
                {
                    _style = value;
                    OnPropertyChanged(nameof(SpecialInstructions));
                }
            }
        }

        /// <summary>
        /// The private backing field for the Count property
        /// </summary>
        private uint _count = 2;

        /// <summary>
        /// How many eggs the Eviscerated Eggs gets
        /// </summary>
        public uint Count
        {
            get
            {
                return _count;
            }
            set
            {
                if (value >= 1 && value <= 6 && value != 2)
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
                    _count = 6;
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(SpecialInstructions));
                }
            }
        }

        /// <summary>
        /// The price of the Eviscerated Eggs
        /// </summary>
        public override decimal Price
        {
            get
            {
                return (decimal)Count;
            }
        }

        /// <summary>
        /// The calories of the Eviscerated Eggs
        /// </summary>
        public override uint Calories
        {
            get
            {
                return (uint)Count * 78u;
            }
        }

        /// <summary>
        /// Special instructions for the preperation of the Eviscerated Eggs
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (Style == EggStyle.SoftBoiled) instructions.Add("Soft Boiled");
                if (Style == EggStyle.HardBoiled) instructions.Add("Hard Boiled");
                if (Style == EggStyle.Scrambled) instructions.Add("Scrambled");
                if (Style == EggStyle.Poached) instructions.Add("Poached");
                if (Style == EggStyle.SunnySideUp) instructions.Add("Sunny Side Up");
                if (Style == EggStyle.OverEasy) instructions.Add("Over Easy");
                if (Count != 2) instructions.Add($"{Count} eggs");
                return instructions;
            }
        }
    }
}
