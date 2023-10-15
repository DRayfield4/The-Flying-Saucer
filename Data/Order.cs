using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Class representing an order containing multiple, potentially
    /// customizable menu items
    /// </summary>
    public class Order : ICollection<IMenuItem>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        /// <summary>
        /// An event for when a collection changes
        /// </summary>
        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        /// <summary>
        /// An event for when a property changes
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Private backing field for the menu items
        /// </summary>
        private List<IMenuItem> _items = new List<IMenuItem>();

        /// <summary>
        /// Private backing field for TaxRate
        /// </summary>
        private decimal _taxRate = 0.15m;

        /// <summary>
        /// Private backing field for Number
        /// </summary>
        private static int _lastNumber = 0;

        /// <summary>
        /// How many items are in the list
        /// </summary>
        public int Count
        {
            get
            {
                return _items.Count;
            }
        }

        /// <summary>
        /// If the list is read only
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// The Subtotal of the item
        /// </summary>
        public decimal Subtotal
        {
            get
            {
                decimal sum = 0;
                foreach (IMenuItem item in _items)
                {
                    sum += item.Price;
                }
                return sum;
            }
        }

        /// <summary>
        /// The tax rate for the total
        /// </summary>
        public decimal TaxRate
        {
            get
            {
                return _taxRate;
            }
            set
            {
                if (_taxRate != value)
                {
                    _taxRate = value;
                    OnPropertyChanged("TaxRate");
                    OnPropertyChanged(nameof(Tax));
                    OnPropertyChanged(nameof(Total));
                }
                else
                {
                    _taxRate = value;
                    OnPropertyChanged("TaxRate");
                    OnPropertyChanged(nameof(Tax));
                    OnPropertyChanged(nameof(Total));
                }
            }
        }

        /// <summary>
        /// The tax for the total
        /// </summary>
        public decimal Tax
        {
            get
            {
                return Subtotal * TaxRate;
            }
        }

        /// <summary>
        /// The total for the order
        /// </summary>
        public decimal Total
        {
            get
            {
                return Subtotal + Tax;
            }
        }

        /// <summary>
        /// The number of the order
        /// </summary>
        public int Number { get; }

        /// <summary>
        /// The time the order was placed at
        /// </summary>
        public DateTime PlacedAt { get; init; }

        /// <summary>
        /// A constructor for the Number and PlacedAt properties
        /// </summary>
        public Order()
        {
            Number = ++_lastNumber;
            PlacedAt = DateTime.Now;
        }

        /// <summary>
        /// Adds an item to the list
        /// </summary>
        /// <param name="item">The item to add</param>
        public void Add(IMenuItem item)
        {
            _items.Add(item);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
        }

        /// <summary>
        /// Clears all items from the list
        /// </summary>
        public void Clear()
        {
            _items.Clear();
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
        }

        /// <summary>
        /// Checks if the list contains a certain item
        /// </summary>
        /// <param name="item">The item to be checked</param>
        /// <returns>If the list contains the item</returns>
        public bool Contains(IMenuItem item)
        {
            return _items.Contains(item);
        }

        /// <summary>
        /// Copies the elements in the list to an array
        /// </summary>
        /// <param name="array">The array to add the list to</param>
        /// <param name="arrayIndex">The index to add to</param>
        public void CopyTo(IMenuItem[] array, int arrayIndex)
        {
            _items.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes an item from the list
        /// </summary>
        /// <param name="item">The item to remove</param>
        /// <returns>If the item was removed</returns>
        public bool Remove(IMenuItem item)
        {
            int index = _items.IndexOf(item);
            bool result = _items.Remove(item);
            if (result)
            {
                CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item, index));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
            }
            return result;
        }

        /// <summary>
        /// Iterates over the list
        /// </summary>
        /// <returns>The enumerator of the list</returns>
        public IEnumerator<IMenuItem> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        /// <summary>
        /// Iterates over the list
        /// </summary>
        /// <returns>An instance of the IEnumerator interface</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<IMenuItem>)_items).GetEnumerator();
        }

        /// <summary>
        /// Handles the CollectionChanged event
        /// </summary>
        /// <param name="e">The event</param>
        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Handles the PropertyChanged event
        /// </summary>
        /// <param name="propertyName">The name of the property that changed</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
