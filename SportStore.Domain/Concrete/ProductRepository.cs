using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportStore.Domain.Abstract;
using SportStore.Domain.Entities;

namespace SportStore.Domain.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Entities.Product> Products
        {
            get { return context.Products; }
        }

        public void SaveProduct(Product product)
        {
            var productEF = context.Products.Find(product.ProductID);
            if(productEF == null)
            {
                productEF = context.Products.Add(product);
            }
            else
            {
                productEF.Name = product.Name;
                productEF.Category = product.Category;
                productEF.Description = product.Description;
                productEF.Price = product.Price;
                productEF.ImageMimeType = product.ImageMimeType;
                productEF.ImageData = product.ImageData;
            }
            context.SaveChanges();
        }

        public Product DeleteProduct(int productId)
        {
            var productEF = context.Products.Find(productId);
            if(productEF != null)
            {
                context.Products.Remove(productEF);
                context.SaveChanges();
            }
            return productEF;
        }
    }
}
