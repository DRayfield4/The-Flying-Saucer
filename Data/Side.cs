using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Abstract base class for Sides.
    /// </summary>
    public abstract class Side : IMenuItem, INotifyPropertyChanged
    {
        /// <summary>
        /// Declare the PropertyChanged event.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Declare the OnPropertyChanged method
        /// </summary>
        /// <param name="propertyName">The name of the property changed.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Abstract property for Sides.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Abstract Description property for Sides.
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// Virtual Price property for Sides.
        /// </summary>
        public abstract decimal Price { get; }

        /// <summary>
        /// Virtual Calories property for Sides.
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// Virtual SpecialInstructions property for Sides.
        /// </summary>
        public abstract IEnumerable<string> SpecialInstructions { get; }

        /// <summary>
        /// Returns the name of the menu item
        /// </summary>
        /// <returns>Menu item name</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
