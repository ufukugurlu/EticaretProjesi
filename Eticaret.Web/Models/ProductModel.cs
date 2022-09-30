using System.Collections.Generic;
using Eticaret.Data.Entities;

namespace Eticaret.Web.Models
{
    public class ProductModel
    {
        public class fnListele
        {
            public IEnumerable<Product> liste { get; set; }
            public int toplam_kayit_sayisi { get; set; }
        }
    }
}
