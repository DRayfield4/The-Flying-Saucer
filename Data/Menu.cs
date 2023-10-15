using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// All the menu items
    /// </summary>
    public static class Menu
    {
        /// <summary>
        /// All available entrees
        /// </summary>
        public static IEnumerable<IMenuItem> Entrees => new List<IMenuItem>
        {
            new FlyingSaucer(),
            new CrashedSaucer(),
            new LivestockMutilation(),
            new OuterOmelette()
        };

        /// <summary>
        /// All available sides
        /// </summary>
        public static IEnumerable<IMenuItem> Sides => new List<IMenuItem>
        {
            new CropCircle(),
            new GlowingHaystack(),
            new TakenBacon(),
            new MissingLinks(),
            new EvisceratedEggs(),
            new YoureToast()
        };

        /// <summary>
        /// All available drinks
        /// </summary>
        public static IEnumerable<IMenuItem> Drinks => new List<IMenuItem>
        {
            new LiquifiedVegetation() { Size = ServingSize.Small },
            new LiquifiedVegetation() { Size = ServingSize.Large },
            new SaucerFuel() { Size = ServingSize.Small },
            new SaucerFuel() { Size = ServingSize.Large },
            new InorganicSubstance() { Size = ServingSize.Small },
            new InorganicSubstance() { Size = ServingSize.Large }
        };

        /// <summary>
        /// All items on the menu
        /// </summary>
        public static IEnumerable<IMenuItem> FullMenu
        {
            get
            {
                var menu = new List<IMenuItem>();
                menu.AddRange(Entrees);
                menu.AddRange(Sides);
                menu.AddRange(Drinks);
                return menu;
            }
        }
    }
}
