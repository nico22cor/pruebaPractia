using Prueba_Practia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prueba_Practia.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            using (FacturacionDBEntities db = new FacturacionDBEntities())
            {
                return View(db.Client.ToList());
            }
                
        }

        
        public ActionResult Details(int id)
        {
            using (FacturacionDBEntities db = new FacturacionDBEntities())
            {
                return View(db.Invoice.Where(x=> x.ClientId == id).ToList());
            }
               
        }

        public ActionResult InvoiceDetails(int id)
        {
            using (FacturacionDBEntities db = new FacturacionDBEntities())
            {
                
                var query =(from ind in db.InvoiceDetail
                            join p in db.Product on ind.ProductId equals p.ProductId into indp
                            from p in indp.DefaultIfEmpty()
                            where ind.InvoiceId == id
                            select new {
                                      invoice = ind,
                                      product = p

                            }).ToList();
                List<InvoiceProduct> lista = new List<InvoiceProduct>();
                foreach (var item in query) {  
                    lista.Add(new InvoiceProduct()
                    {
                        InvoiceDetailId = item.invoice.InvoiceDetailId,
                        InvoiceId = item.invoice.InvoiceId,
                        ProductId = item.invoice.ProductId,
                        Amount = item.invoice.Amount,
                        SellPrice = item.invoice.SellPrice,
                        Total = item.invoice.Total,
                        Name = item.product.Name,
                        UnitPrice = item.product.UnitPrice
                    });
                }

                return View(lista);
            }

        }


    }
}
