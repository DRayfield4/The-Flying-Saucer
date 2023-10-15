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
using System.Collections.ObjectModel;
using TheFlyingSaucer.Data;

namespace TheFlyingSaucer.PointOfSale
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes the components
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Order();
        }

        /*
        /// <summary>
        /// Handles a click on the Cancel Order button
        /// </summary>
        /// <param name="sender">The object for this event</param>
        /// <param name="e">Metadata for event</param>
        public void CancelOrderClicked(Object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Handles a click on the Back to Menu button
        /// </summary>
        /// <param name="sender">The object for this event</param>
        /// <param name="e">Metadata for event</param>
        public void BackToMenuClicked(Object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Handles a click on the Complete Order button
        /// </summary>
        /// <param name="sender">The object for this event</param>
        /// <param name="e">Metadata for event</param>
        public void CompleteOrderClicked(Object sender, RoutedEventArgs e)
        {

        }
        */
    }
}