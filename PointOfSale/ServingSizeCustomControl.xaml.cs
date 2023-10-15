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
    /// Interaction logic for ServingSizeCustomControl.xaml
    /// </summary>
    public partial class ServingSizeCustomControl : UserControl
    {
        public ServingSizeCustomControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// SizeProperty DependencyProject
        /// </summary>
        public static readonly DependencyProperty SizeProperty = DependencyProperty.Register(
            nameof(Size),
            typeof(uint),
            typeof(ServingSizeCustomControl),
            new FrameworkPropertyMetadata(0u, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// The size for the control
        /// </summary>
        public uint Size
        {
            get
            {
                return (uint)GetValue(SizeProperty);
            }
            set
            {
                SetValue(SizeProperty, value);
            }
        }
    }
}
