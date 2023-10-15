using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for OrderSummaryControl.xaml
    /// </summary>
    public partial class OrderSummaryControl : UserControl
    {
        /// <summary>
        /// Event for clicking on edit button
        /// </summary>
        public event EventHandler<IMenuItem> EditMenuItemClicked;

        public OrderSummaryControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles a click on the edit button
        /// </summary>
        /// <param name="sender">The object sender fpor this event</param>
        /// <param name="e">The event args for this event</param>
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = ((Button)sender).DataContext as IMenuItem;
            EditMenuItemClicked?.Invoke(this, menuItem);
        }

        /// <summary>
        /// Handles a click on the remove button
        /// </summary>
        /// <param name="sender">The object sender for this event</param>
        /// <param name="e">The event args for this event</param>
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = ((Button)sender).DataContext as IMenuItem;
            var order = (Order)DataContext;
            order.Remove(menuItem);
        }
    }
}
