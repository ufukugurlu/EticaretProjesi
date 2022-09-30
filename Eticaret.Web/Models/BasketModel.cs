using System.Collections.Generic;
using Eticaret.Data.Entities;

namespace Eticaret.Web.Models
{
    public class BasketModel
    {
        public class fnListele
        {
            public IEnumerable<Basket> liste { get; set; }
            public int toplam_kayit_sayisi { get; set; }
            public string degerler { get; set; }
        }
    }
}
