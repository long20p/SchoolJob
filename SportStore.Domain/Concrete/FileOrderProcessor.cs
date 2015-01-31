using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using SportStore.Domain.Abstract;
using SportStore.Domain.Entities;

namespace SportStore.Domain.Concrete
{
    public class FileOrderProcessor : IOrderProcessor
    {
        public void ProcessOrder(ShoppingCart cart, ShippingDetails shippingDetails)
        {
            StringBuilder body = new StringBuilder()
                    .AppendLine("A new order has been submitted")
                    .AppendLine("---")
                    .AppendLine("Items:");

            foreach (var line in cart.Lines)
            {
                var subtotal = line.Product.Price * line.Quantity;
                body.AppendFormat("{0} x {1} (subtotal: {2:c}", line.Quantity,
                line.Product.Name,
                subtotal);
                body.AppendLine();
            }

            body.AppendFormat("Total order value: {0:c}", cart.ComputeTotalValue())
                    .AppendLine()
                    .AppendLine("---")
                    .AppendLine("Ship to:")
                    .AppendLine(shippingDetails.Name)
                    .AppendLine(shippingDetails.Line1)
                    .AppendLine(shippingDetails.Line2 ?? "")
                    .AppendLine(shippingDetails.Line3 ?? "")
                    .AppendLine(shippingDetails.City)
                    .AppendLine(shippingDetails.State ?? "")
                    .AppendLine(shippingDetails.Country)
                    .AppendLine(shippingDetails.Zip)
                    .AppendLine("---")
                    .AppendFormat("Gift wrap: {0}",
                    shippingDetails.GiftWrap ? "Yes" : "No");

            using(FileStream fs = new FileStream(@"E:\order.txt", FileMode.CreateNew, FileAccess.Write))
            using(StreamWriter sr = new StreamWriter(fs))
            {
                sr.Write(body.ToString());
                sr.Flush();
            }
        }
    }
}
