using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportStore.Domain.Entities;
using SportStore.WebUI.Models;

namespace SportStore.UnitTests
{
    [TestClass]
    public class CartTest
    {
        [TestMethod]
        public void Can_Add_New_Lines()
        {
            var p1 = new Product { ProductID = 1, Name = "P1" };
            var p2 = new Product { ProductID = 2, Name = "P2" };

            var cart = new ShoppingCart();
            cart.AddItem(p1, 1);
            cart.AddItem(p2, 3);

            Assert.AreEqual(2, cart.Lines.Count());
            Assert.AreEqual("P2", cart.Lines.ElementAt(1).Product.Name);
        }

        [TestMethod]
        public void Can_Add_Existing_Product()
        {
            var p1 = new Product { ProductID = 1, Name = "P1" };
            var p2 = new Product { ProductID = 2, Name = "P2" };

            var cart = new ShoppingCart();
            cart.AddItem(p1, 1);
            cart.AddItem(p2, 3);
            cart.AddItem(p1, 6);

            Assert.AreEqual(2, cart.Lines.Count());
            Assert.AreEqual(7, cart.Lines.ElementAt(0).Quantity);
        }
    }
}
