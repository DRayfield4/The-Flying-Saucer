namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Details for the Flying Saucer restaurant
    /// </summary>
    public class FlyingSaucer : Entree
    {
        /// <summary>
        /// Private backing field for Syrup
        /// </summary>
        private bool _syrup = true;

        /// <summary>
        /// Private backing field for WhippedCream
        /// </summary>
        private bool _whippedCream = true;

        /// <summary>
        /// Private backing field for Berries
        /// </summary>
        private bool _berries = true;

        /// <summary>
        /// The name of the Flying Saucer instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public override string Name { get; } = "Flying Saucer";

        /// <summary>
        /// The description of the Flying Saucer instance
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public override string Description => "A stack of six pancakes, smothered in rich maple syrup, and topped with mixed berries and whipped cream.";

        /// <summary>
        /// The private backing field for the StackSize property
        /// </summary>
        private uint _stackSize = 6;

        /// <summary>
        /// The number of panacakes in this instance of a Flying Saucer
        /// </summary>
        /// <remarks>
        /// Note the set limits the stack size to a maximum of 12 pancakes
        /// </remarks>
        public uint StackSize { 
            get 
            { 
                return _stackSize; 
            }
            set
            {
                if (value <= 12 && value != 2)
                {
                    _stackSize = value;
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(SpecialInstructions));
                }
                else if(value == 2)
                {
                    _stackSize = 2;
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(Calories));
                }
                else
                {
                    _stackSize = 12;
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(SpecialInstructions));
                }
            }
        }

        /// <summary>
        /// If the Fying Saucer instance is served with maple syrup
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
                if(_syrup != value)
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
        /// If the Flying Saucer instance is served with whipped cream
        /// </summary>
        public bool WhippedCream
        {
            get
            {
                return _whippedCream;
            }
            set
            {
                if(_whippedCream != value)
                {
                    _whippedCream = value;
                    OnPropertyChanged(nameof(SpecialInstructions));
                }
                else
                {
                    _whippedCream = value;
                    OnPropertyChanged(nameof(Calories));
                }
            }
        }

        /// <summary>
        /// If the Flying Saucer instance is served with berries
        /// </summary>
        public bool Berries
        {
            get
            {
                return _berries;
            }
            set
            {
                if(_berries != value)
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
        /// The price of the Flying Saucer instance
        /// </summary>
        public override decimal Price
        {
            get
            {
                if(StackSize > 6)
                {
                    return 8.50m + (((decimal)StackSize - 6) * 0.75m);
                }
                /*else if(StackSize < 6)
                {
                    return 8.50m - ((6 - (decimal)StackSize) * 0.5m);
                }*/
                else
                {
                    return 8.50m;
                }
            }
        }

        /// <summary>
        /// The calories of the Flying Saucer instance
        /// </summary>
        /// <remarks>
        /// This is a get-only property whose value is derived from the other properties of the class.
        /// </remarks>
        public override uint Calories
        {
            get
            {
                uint calories = 64u * StackSize;
                if (Syrup) calories += 32u;
                if (WhippedCream) calories += 414u;
                if (Berries) calories += 89u;
                return calories;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this Flying Saucer
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (StackSize != 6) instructions.Add($"{StackSize} Pancakes");
                if (!Syrup) instructions.Add("Hold syrup");
                if (!WhippedCream) instructions.Add("Hold whipped cream");
                if (!Berries) instructions.Add("Hold berries");
                return instructions;
            }
        }

    }
}