using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Abstract base class for Drinks.
    /// </summary>
    public abstract class Drink : IMenuItem, INotifyPropertyChanged
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
        /// Abstract property for Drinks.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Abstract Description property for Drinks.
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// Size property for Drinks.
        /// </summary>
        public abstract ServingSize Size { get; set; }

        /// <summary>
        /// Virtual Price property for Drinks.
        /// </summary>
        public abstract decimal Price { get; }

        /// <summary>
        /// Virtual Calories property for Drinks.
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// Virtual SpecialInstructions property for Drinks.
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
