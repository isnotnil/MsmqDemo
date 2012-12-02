using System;
using System.ServiceModel;
using System.Web.Mvc;
using MsmqDemo.Services.Shared;
using MsmqDemo.Web.Models;

namespace MsmqDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var order = new Order
                            {
                                RequestedDeliveryDate = DateTime.Now.AddDays(14)
                            };
            return View(order);
        }

        [HttpPost]
        public ActionResult Index(Order order)
        {
            if (ModelState.IsValid)
            {
                SumbitOrder(order);
                return View("ThankYou");
            }
            return View(order);
        }

        private static void SumbitOrder(Order order)
        {
            var request = new OrderRequest
                              {
                                  ConfirmationEmailAddress = order.EmailAddress,
                                  RequestedDeliveryDate = order.RequestedDeliveryDate.Date,
                                  VendorNumber = order.VenderNumber
                              };
            if (order.QuantityBottledRainbows > 0)
            {
                var item = new OrderLineItem
                               {
                                   ProductIdentifier = "BottledRainbows",
                                   Quanity = order.QuantityBottledRainbows
                               };
                request.LineItems.Add(item);
            }
            if (order.QuantityEsessenceOfBacon > 0)
            {
                var item = new OrderLineItem
                {
                    ProductIdentifier = "EsessenceOfBacon",
                    Quanity = order.QuantityEsessenceOfBacon
                };
                request.LineItems.Add(item);
            }
            if (order.QuantityPowderedUnicornHorns > 0)
            {
                var item = new OrderLineItem
                {
                    ProductIdentifier = "PowderedUnicornHorns",
                    Quanity = order.QuantityPowderedUnicornHorns
                };
                request.LineItems.Add(item);
            }

            // TODO: Send to Service
        }
    }
}
