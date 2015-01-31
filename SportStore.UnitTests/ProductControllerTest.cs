using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using SportStore.Domain.Abstract;
using SportStore.Domain.Entities;
using SportStore.WebUI.Controllers;
using SportStore.WebUI.Models;

namespace SportStore.UnitTests
{
    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
        public void Can_Paginate()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product{ ProductID = 1, Name = "P1"},
                new Product{ ProductID = 2, Name = "P2"},
                new Product{ ProductID = 3, Name = "P3"},
                new Product{ ProductID = 4, Name = "P4"},
                new Product{ ProductID = 5, Name = "P5"},
                new Product{ ProductID = 6, Name = "P6"},
                new Product{ ProductID = 7, Name = "P7"},
            }.AsQueryable());

            ProductController target = new ProductController(mock.Object);

            var page3 = target.List(null, 4).Model as ProductListViewModel;

            Assert.IsTrue(page3.Products.Count() == 1);
            Assert.AreEqual("P7", page3.Products.ElementAt(0).Name);
            Assert.AreEqual(7, page3.PagingInfo.TotalItems);
            Assert.AreEqual(4, page3.PagingInfo.TotalPages);
        }
    }
}
