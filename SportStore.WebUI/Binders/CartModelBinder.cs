using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportStore.Domain.Entities;

namespace SportStore.WebUI.Binders
{
    public class CartModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var cart = controllerContext.HttpContext.Session["Cart"] as ShoppingCart;
            if(cart == null)
            {
                cart = new ShoppingCart();
                controllerContext.HttpContext.Session["Cart"] = cart;
            }
            return cart;
        }
    }
}