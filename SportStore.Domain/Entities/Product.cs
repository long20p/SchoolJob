using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SportStore.Domain.Entities
{
    [MetadataType(typeof(ProductMetadata))]
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }

    public class ProductMetadata
    {
        [HiddenInput(DisplayValue = false)]
        public object ProductID { get; set; }

        [Required(ErrorMessage = "Enter product name")]
        public object Name { get; set; }

        [DataType(DataType.MultilineText)]
        public object Description { get; set; }

        [Required(ErrorMessage = "Price is mandatory")]
        [Range(0.01, Double.MaxValue)]
        public object Price { get; set; }

        [HiddenInput(DisplayValue = false)]
        public object ImageMimeType { get; set; }
    }
}
