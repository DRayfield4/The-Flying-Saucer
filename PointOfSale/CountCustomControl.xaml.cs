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

namespace TheFlyingSaucer.PointOfSale
{
    /// <summary>
    /// Interaction logic for CountCustomControl.xaml
    /// </summary>
    public partial class CountCustomControl : UserControl
    {
        public CountCustomControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// CountProperty DependencyProject
        /// </summary>
        public static readonly DependencyProperty CountProperty = DependencyProperty.Register(
            nameof(Count),
            typeof(uint),
            typeof(CountCustomControl),
            new FrameworkPropertyMetadata(0u, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// The count for the control
        /// </summary>
        public uint Count
        {
            get
            {
                return (uint)GetValue(CountProperty);
            }
            set
            {
                SetValue(CountProperty, value);
            }
        }

        /// <summary>
        /// Event handler for Increment
        /// </summary>
        /// <param name="sender">Meta data</param>
        /// <param name="e">Event</param>
        private void HandleIncrement(object sender, RoutedEventArgs e)
        {
            if (Count != uint.MaxValue) Count++;
            e.Handled = true;
        }

        /// <summary>
        /// Event handler for Decrement
        /// </summary>
        /// <param name="sender">Meta data</param>
        /// <param name="e">Event</param>
        private void HandleDecrement(object sender, RoutedEventArgs e)
        {
            if (Count != 0) Count--;
            e.Handled = true;
        }
    }
}
