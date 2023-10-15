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
    /// Interaction logic for StackSizeCustomControl.xaml
    /// </summary>
    public partial class StackSizeCustomControl : UserControl
    {
        public StackSizeCustomControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// StackSizeProperty DependencyProject
        /// </summary>
        public static readonly DependencyProperty StackSizeProperty = DependencyProperty.Register(
            nameof(StackSize),
            typeof(uint),
            typeof(CountCustomControl),
            new FrameworkPropertyMetadata(0u, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// The count for the control
        /// </summary>
        public uint StackSize
        {
            get
            {
                return (uint)GetValue(StackSizeProperty);
            }
            set
            {
                SetValue(StackSizeProperty, value);
            }
        }

        /// <summary>
        /// Event handler for Increment
        /// </summary>
        /// <param name="sender">Meta data</param>
        /// <param name="e">Event</param>
        private void HandleIncrement(object sender, RoutedEventArgs e)
        {
            if (StackSize != uint.MaxValue) StackSize++;
            e.Handled = true;
        }

        /// <summary>
        /// Event handler for Decrement
        /// </summary>
        /// <param name="sender">Meta data</param>
        /// <param name="e">Event</param>
        private void HandleDecrement(object sender, RoutedEventArgs e)
        {
            if (StackSize != 0) StackSize--;
            e.Handled = true;
        }
    }
}
