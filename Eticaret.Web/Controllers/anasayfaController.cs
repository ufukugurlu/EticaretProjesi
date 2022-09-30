using System;
using System.Collections.Generic;
using Eticaret.Data.Entities;
using Eticaret.Data.EntityFramework;
using Eticaret.Data.UnitOfWork;
using Eticaret.Web.Classes;
using Eticaret.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Web.Controllers
{
    public class anasayfaController : Controller
    {
        private readonly Fonksiyonlar fn = new();
        [Route("/")]
        [Authorize]
        public IActionResult Index(string ara, string sayfa)
        {
            int intToplam_Kayit = 0;
            int intGosterim_Adeti = 10;
            int intSayfa = 1;
            if (fn.fnSayisal_Mi(sayfa))
                intSayfa = Convert.ToInt32(sayfa);
            int intBaslangic_Degeri = (intGosterim_Adeti * intSayfa) - intGosterim_Adeti;
            EticaretDBContext context = new EticaretDBContext();
            UnitOfWork baglanti = new UnitOfWork(context);

            if (string.IsNullOrEmpty(ara))
                ara = null;

            IList<Product> liste = baglanti.IEFProductsRepository.fnListele(intBaslangic_Degeri, intGosterim_Adeti, out intToplam_Kayit);

            ProductModel.fnListele model = new()
            {
                liste = liste,
                toplam_kayit_sayisi = intToplam_Kayit
            };

            return View(model);
        }
    }
}
