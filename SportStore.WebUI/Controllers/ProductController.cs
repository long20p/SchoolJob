using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportStore.Domain.Abstract;
using SportStore.Domain.Entities;
using SportStore.WebUI.Models;

namespace SportStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private const int pageSize = 2;

        private IProductRepository repository;

        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string category, int page = 1)
        {
            var products = repository.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
            var paging = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = pageSize,
                TotalItems = repository.Products.Count(p => category == null || p.Category == category)
            };
            return View(new ProductListViewModel
                {
                    PagingInfo = paging,
                    Products = products,
                    CurrentCategory = category
                });
        }

        public FileContentResult GetImage(int productId)
        {
            var product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
                return File(product.ImageData, product.ImageMimeType);
            return null;
        }
    }
}
