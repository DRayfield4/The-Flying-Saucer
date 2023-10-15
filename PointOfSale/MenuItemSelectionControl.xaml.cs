using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TheFlyingSaucer.Data;

namespace TheFlyingSaucer.PointOfSale
{
    /// <summary>
    /// Interaction logic for MenuItemSelectionControl.xaml
    /// </summary>
    public partial class MenuItemSelectionControl : UserControl
    {
        /// <summary>
        /// Initializes the MenuItemSelectionControl
        /// </summary>
        public MenuItemSelectionControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles a click on the Flying Saucer menu item and adds it to the Order Summary.
        /// </summary>
        /// <param name="sender">The object for this event</param>
        /// <param name="e">Metadata for event</param>
        public void FlyingSaucerClicked(Object sender, RoutedEventArgs e)
        {
            FlyingSaucer fs = new();
            if (DataContext is ICollection<IMenuItem> collection)
            {
                collection.Add(fs);
            }
        }

        /// <summary>
        /// Handles a click on the Crashed Saucer menu item and adds it to the Order Summary.
        /// </summary>
        /// <param name="sender">The object for this event</param>
        /// <param name="e">Metadata for event</param>
        public void CrashedSaucerClicked(Object sender, RoutedEventArgs e)
        {
            CrashedSaucer cs = new();
            if (DataContext is ICollection<IMenuItem> collection)
            {
                collection.Add(cs);
            }
        }

        /// <summary>
        /// Handles a click on the Livestock Mutilation menu item and adds it to the Order Summary.
        /// </summary>
        /// <param name="sender">The object for this event</param>
        /// <param name="e">Metadata for event</param>
        public void LivestockMutilationClicked(Object sender, RoutedEventArgs e)
        {
            LivestockMutilation lm = new();
            if (DataContext is ICollection<IMenuItem> collection)
            {
                collection.Add(lm);
            }
        }

        /// <summary>
        /// Handles a click on the Outer Omelette menu item and adds it to the Order Summary.
        /// </summary>
        /// <param name="sender">The object for this event</param>
        /// <param name="e">Metadata for event</param>
        public void OuterOmeletteClicked(Object sender, RoutedEventArgs e)
        {
            OuterOmelette oo = new();
            if (DataContext is ICollection<IMenuItem> collection)
            {
                collection.Add(oo);
            }
        }

        /// <summary>
        /// Handles a click on the Crop Circle menu item and adds it to the Order Summary.
        /// </summary>
        /// <param name="sender">The object for this event</param>
        /// <param name="e">Metadata for event</param>
        public void CropCircleClicked(Object sender, RoutedEventArgs e)
        {
            CropCircle cc = new();
            if (DataContext is ICollection<IMenuItem> collection)
            {
                collection.Add(cc);
            }
        }

        /// <summary>
        /// Handles a click on the Glowing Haystack menu item and adds it to the Order Summary.
        /// </summary>
        /// <param name="sender">The object for this event</param>
        /// <param name="e">Metadata for event</param>
        public void GlowingHaystackClicked(Object sender, RoutedEventArgs e)
        {
            GlowingHaystack gh = new();
            if (DataContext is ICollection<IMenuItem> collection)
            {
                collection.Add(gh);
            }
        }

        /// <summary>
        /// Handles a click on the Taken Bacon menu item and adds it to the Order Summary.
        /// </summary>
        /// <param name="sender">The object for this event</param>
        /// <param name="e">Metadata for event</param>
        public void TakenBaconClicked(Object sender, RoutedEventArgs e)
        {
            TakenBacon tb = new();
            if (DataContext is ICollection<IMenuItem> collection)
            {
                collection.Add(tb);
            }
        }

        /// <summary>
        /// Handles a click on the Missing Links menu item and adds it to the Order Summary.
        /// </summary>
        /// <param name="sender">The object for this event</param>
        /// <param name="e">Metadata for event</param>
        public void MissingLinksClicked(Object sender, RoutedEventArgs e)
        {
            MissingLinks ml = new();
            if (DataContext is ICollection<IMenuItem> collection)
            {
                collection.Add(ml);
            }
        }

        /// <summary>
        /// Handles a click on the Eviscerated Eggs menu item and adds it to the Order Summary.
        /// </summary>
        /// <param name="sender">The object for this event</param>
        /// <param name="e">Metadata for event</param>
        public void EvisceratedEggsClicked(Object sender, RoutedEventArgs e)
        {
            EvisceratedEggs ee = new();
            if (DataContext is ICollection<IMenuItem> collection)
            {
                collection.Add(ee);
            }
        }

        /// <summary>
        /// Handles a click on the Youre Toast menu item and adds it to the Order Summary.
        /// </summary>
        /// <param name="sender">The object for this event</param>
        /// <param name="e">Metadata for event</param>
        public void YoureToastClicked(Object sender, RoutedEventArgs e)
        {
            YoureToast yt = new();
            if (DataContext is ICollection<IMenuItem> collection)
            {
                collection.Add(yt);
            }
        }

        /// <summary>
        /// Handles a click on the Liquified Vegetation menu item and adds it to the Order Summary.
        /// </summary>
        /// <param name="sender">The object for this event</param>
        /// <param name="e">Metadata for event</param>
        public void LiquifiedVegetationClicked(Object sender, RoutedEventArgs e)
        {
            LiquifiedVegetation lv = new();
            if (DataContext is ICollection<IMenuItem> collection)
            {
                collection.Add(lv);
            }
        }

        /// <summary>
        /// Handles a click on the Saucer Fuel menu item and adds it to the Order Summary.
        /// </summary>
        /// <param name="sender">The object for this event</param>
        /// <param name="e">Metadata for event</param>
        public void SaucerFuelClicked(Object sender, RoutedEventArgs e)
        {
            SaucerFuel sf = new();
            if (DataContext is ICollection<IMenuItem> collection)
            {
                collection.Add(sf);
            }
        }

        /// <summary>
        /// Handles a click on the Inorganic Substance menu item and adds it to the Order Summary.
        /// </summary>
        /// <param name="sender">The object for this event</param>
        /// <param name="e">Metadata for event</param>
        public void InorganicSubstanceClicked(Object sender, RoutedEventArgs e)
        {
            InorganicSubstance sub = new();
            if (DataContext is ICollection<IMenuItem> collection)
            {
                collection.Add(sub);
            }
        }
    }
}