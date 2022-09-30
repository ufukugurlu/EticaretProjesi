using Eticaret.Data.Entities;
using Eticaret.Web.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;

namespace Eticaret.Web.Controllers
{
    public class ajaxController : Controller
    {
        private Fonksiyonlar fn = new ();
        [Route("ajax/sepete-ekle")]
        [HttpPost]
        public IActionResult sepete_ekle(IFormCollection fcDegerler)
        {
            string strUrunId = fcDegerler["urunid"];
            string strUrunAdi = fcDegerler["urunadi"];
            int intUrunId = Convert.ToInt32(strUrunId);
            if (HttpContext.Session.GetString("sepet-" + strUrunId) == null)
            {
                Basket sepetEntity = new Basket()
                {
                    Id = 0,
                    ProductId = intUrunId,
                    UserId = 0,
                    Total = 1,
                    ProductName = strUrunAdi
                };
                byte[] bytSepet = fn.ObjectToByteArray(sepetEntity);
                HttpContext.Session.Set("sepet-" + strUrunId, bytSepet);
            }
            else
            {
                byte[] bytSepet = HttpContext.Session.Get("sepet-" + strUrunId);
                if (bytSepet != null)
                {
                    Basket sepetEntity = fn.FromByteArray<Basket>(bytSepet);
                    sepetEntity.Total += 1;

                    byte[] bytSepetYeni = fn.ObjectToByteArray(sepetEntity);
                    HttpContext.Session.Set("sepet-" + strUrunId, bytSepetYeni);
                }
            }

            return Ok("Ürün sepete eklendi");
        }
    }
}
