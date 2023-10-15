using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFlyingSaucer.Data;
using Xunit;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the Order class
    /// </summary>
    public class OrderUnitTest
    {
        /// <summary>
        /// Tests the Subtotal property
        /// </summary>
        [Fact]
        public void SubtotalShouldReflectItemPrices()
        {
            Order order = new Order();
            order.Add(new MockMenuItem() { Price = 1.00m });
            order.Add(new MockMenuItem() { Price = 2.50m });
            order.Add(new MockMenuItem() { Price = 3.00m });
            Assert.Equal(6.50m, order.Subtotal);
        }

        /// <summary>
        /// Tests the default Count property
        /// </summary>
        [Fact]
        public void CountDefault()
        {
            Order oo = new();
            Assert.Empty(oo);
        }

        /// <summary>
        /// Tests the Read Only property
        /// </summary>
        [Fact]
        public void TestReadOnly()
        {
            Order oo = new();
            Assert.False(oo.IsReadOnly);
        }

        /// <summary>
        /// Tests different tax rates
        /// </summary>
        /// <param name="taxRate">The tax rate</param>
        [Theory]
        [InlineData(1.3)]
        [InlineData(2)]
        [InlineData(0.8)]
        public void TaxRate(decimal taxRate)
        {
            Order oo = new();
            oo.TaxRate = taxRate;
            Assert.Equal(taxRate, oo.TaxRate);
        }

        /// <summary>
        /// tests different tax rates
        /// </summary>
        /// <param name="rate">The tax rate</param>
        [Theory]
        [InlineData(1.5)]
        [InlineData(2)]
        [InlineData(0.8)]
        public void Tax(decimal rate)
        {
            Order oo = new();
            oo.TaxRate = rate;
            Assert.Equal((oo.Subtotal * rate), oo.Tax);
        }

        /// <summary>
        /// Tests the total
        /// </summary>
        [Fact]
        public void CorrectTotal()
        {
            Order oo = new();
            Assert.Equal((oo.Subtotal + oo.Tax), oo.Total);
        }

        /// <summary>
        /// Tests the count
        /// </summary>
        /// <param name="count">How many items are being added</param>
        [Theory]
        [InlineData(4)]
        [InlineData(0)]
        [InlineData(3)]
        [InlineData(1)]
        public void Count(int count)
        {
            Order oo = new();
            MockMenuItem item = new();

            for(int i = 0; i < count; i++)
            {
                oo.Add(item);
            }

            Assert.Equal(count, oo.Count);
        }

        /// <summary>
        /// Tests the clear method
        /// </summary>
        /// <param name="count">How many items are in the list</param>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void Clear(int count)
        {
            Order oo = new();
            MockMenuItem item = new();

            for (int i = 0; i < count; i++)
            {
                oo.Add(item);
            }

            oo.Clear();
            Assert.Empty(oo);
        }

        /// <summary>
        /// Tests if the list contains a certain item
        /// </summary>
        [Fact]
        public void ContainsItem()
        {
            Order oo = new();
            MockMenuItem item = new();
            oo.Add(item);

            Assert.Contains(item, oo);
        }

        /// <summary>
        /// Tests if the list doesn't contain a certain item
        /// </summary>
        [Fact]
        public void DoesntContainsItem()
        {
            Order oo = new();
            MockMenuItem item = new();

            Assert.DoesNotContain(item, oo);
        }

        /// <summary>
        /// Tests copying items to list
        /// </summary>
        [Fact]
        public void CopyTo()
        {
            Order oo = new();
            MockMenuItem item1 = new();
            MockMenuItem item2 = new();
            MockMenuItem item3 = new();
            oo.Add(item1);
            oo.Add(item2);
            oo.Add(item3);

            var array = new IMenuItem[3];

            oo.CopyTo(array, 0);

            Assert.Equal(item1, array[0]);
            Assert.Equal(item2, array[1]);
            Assert.Equal(item3, array[2]);
        }

        /// <summary>
        /// Tests for removing items
        /// </summary>
        [Fact]
        public void Remove()
        {
            Order oo = new();
            MockMenuItem item = new();
            oo.Add(item);

            var removed = oo.Remove(item);

            Assert.True(removed);
            Assert.Empty(oo);
        }

        /// <summary>
        /// Tests the GetEnumerator method properly works
        /// </summary>
        [Fact]
        public void GetEnumerator()
        {
            Order oo = new();
            var item1 = new MockMenuItem { Name = "Item 1", Price = 1.99m };
            var item2 = new MockMenuItem { Name = "Item 2", Price = 2.99m };
            oo.Add(item1);
            oo.Add(item2);

            var enumerator = oo.GetEnumerator();

            Assert.NotNull(enumerator);
            Assert.IsType<List<IMenuItem>.Enumerator>(enumerator);
        }
        
        /// <summary>
        /// Tests the IEnumerable GetEnumerator method properly works
        /// </summary>
        [Fact]
        public void IEnumerableGetEnumerator()
        {
            Order oo = new Order();
            var item1 = new MockMenuItem { Name = "Item 1", Price = 1.99m };
            var item2 = new MockMenuItem { Name = "Item 2", Price = 2.99m };
            oo.Add(item1);
            oo.Add(item2);

            var enumerator = ((IEnumerable)oo).GetEnumerator();

            Assert.NotNull(enumerator);
            Assert.IsType<List<IMenuItem>.Enumerator>(enumerator);
        }

        /// <summary>
        /// Checks that the subtotal still works properly
        /// </summary>
        [Fact]
        public void SubtotalShouldBeCalculatedCorrectly()
        {
            Order order = new Order();
            EvisceratedEggs ee = new();
            GlowingHaystack gh = new();
            order.Add(ee);
            order.Add(gh);

            decimal expectedSubtotal = ee.Price + gh.Price;

            Assert.Equal(expectedSubtotal, order.Subtotal);
        }

        /// <summary>
        /// Checks that the tax still works properly
        /// </summary>
        [Fact]
        public void TaxShouldBeCalculatedCorrectly()
        {
            Order order = new Order();
            EvisceratedEggs ee = new();
            GlowingHaystack gh = new();
            order.Add(ee);
            order.Add(gh);

            decimal expectedTax = (ee.Price + gh.Price) * order.TaxRate;

            Assert.Equal(expectedTax, order.Tax);
        }

        /// <summary>
        /// Checks that the total still works properly
        /// </summary>
        [Fact]
        public void TotalShouldBeCalculatedCorrectly()
        {
            Order order = new Order();
            EvisceratedEggs ee = new();
            GlowingHaystack gh = new();
            order.Add(ee);
            order.Add(gh);

            decimal expectedTotal = (ee.Price + gh.Price) * (1 + order.TaxRate);

            Assert.Equal(expectedTotal, order.Total);
        }
        /*
        /// <summary>
        /// Checks that changing the tax rate should notify property changed
        /// </summary>
        /// <param name="rate">The tax rate</param>
        /// <param name="propertyName">The name of the property changed</param>
        [Theory]
        [InlineData(0.15, "Tax")]
        [InlineData(0.15, "Total")]
        [InlineData(0.17, "Tax")]
        [InlineData(0.17, "Total")]
        public void ChangingTaxRateShouldNotifyOfPropertyChange(decimal rate, string propertyName)
        {
            Order order = new Order();
            Assert.PropertyChanged(order, propertyName, () => {
                order.TaxRate = rate;
            });
        }*/

        /// <summary>
        /// Checks that changing the tax rate should notify property changed
        /// </summary>
        [Fact]
        public void ChangingTaxRateShouldNotifyOfPropertyChange()
        {
            Order order = new Order();
            Assert.PropertyChanged(order, "TaxRate", () => {
                order.TaxRate = 0.15m;
            });
        }

        /// <summary>
        /// Checks that INotifyPropertyChanged is implemented
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            Order order = new Order();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(order);
        }
        /*
        [Fact]
        public void AddingMenuItemShouldTriggerCollectionChangedEvent()
        {
            Order order = new Order();
            EvisceratedEggs ee = new();
            MyAssert.NotifyCollectionChangedAdd();
        }

        [Fact]
        public void RemovingMenuItemShouldTriggerCollectionChangedEvent()
        {
            Order order = new Order();
            EvisceratedEggs ee = new();
            order.Add(ee);
            MyAssert.NotifyCollectionChangedRemove();
        }
        */
        /// <summary>
        /// Checks that INotifyCollectionChanged is implemented
        /// </summary>
        [Fact]
        public void OrderShouldImplementINotifyCollectionChanged()
        {
            Order order = new Order();
            Assert.IsAssignableFrom<INotifyCollectionChanged>(order);
        }
        /*
        /// <summary>
        /// Tests that the Number propery changes accordingly
        /// </summary>
        [Fact]
        public void OrderNumberShouldUpdateForEachSubsequentOrder()
        {
            Order firstOrder = new Order();
            Order secondOrder = new Order();

            Assert.Equal(1, firstOrder.Number);
            Assert.Equal(2, secondOrder.Number);
        }
        */
        /// <summary>
        /// Checks that the PlacedAt property actually reflects when the order was placed
        /// </summary>
        [Fact]
        public void PlacedAtDateAndTimeReflectActual()
        {
            Order order = new();
            Assert.Equal(DateTime.Now.Date, order.PlacedAt.Date);
            Assert.Equal(DateTime.Now.Hour, order.PlacedAt.Hour);
            Assert.Equal(DateTime.Now.Minute, order.PlacedAt.Minute);
        }

        /// <summary>
        /// Checks that the properties don't change when more than one is requested
        /// </summary>
        [Fact]
        public void PropertiesDontChangeWithMoreThanOne()
        {
            Order order = new();
            var firstOrderNumber = order.Number;
            var firstOrderPlacedAt = order.PlacedAt;
            var secondOrderNumber = order.Number;
            var secondOrderPlacedAt = order.PlacedAt;

            Assert.Equal(firstOrderNumber, secondOrderNumber);
            Assert.Equal(firstOrderPlacedAt, secondOrderPlacedAt);
        }
    }
}
