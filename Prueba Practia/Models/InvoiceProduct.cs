using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba_Practia.Models
{
    public class InvoiceProduct
    {
        public int InvoiceDetailId { get; set; }
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public decimal SellPrice { get; set; }
        public Nullable<decimal> Total { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
    }
}