using Eticaret.Data.Entities;
using Eticaret.Web.Classes;
using Eticaret.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Eticaret.Web.Controllers
{
    public class sepetController : Controller
    {
        private Fonksiyonlar fn = new();
        [Route("/sepet")]
        [Authorize]
        public IActionResult Index()
        {
            var liste = new List<Basket>();
            foreach (string strDeger in HttpContext.Session.Keys)
            {
                if (!string.IsNullOrEmpty(strDeger) && strDeger.Contains("sepet-"))
                {
                    byte[] bytSepet = HttpContext.Session.Get(strDeger);
                    Basket sepetEntity = fn.FromByteArray<Basket>(bytSepet);
                    liste.Add(sepetEntity);
                }
            }

            BasketModel.fnListele model = new BasketModel.fnListele
            {
                liste = liste
            };

            return View(model);
        }
    }
}
