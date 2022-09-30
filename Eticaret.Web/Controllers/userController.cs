using Eticaret.Data.Entities;
using Eticaret.Data.EntityFramework;
using Eticaret.Data.UnitOfWork;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Web.Controllers
{
    public class userController : Controller
    {
        [HttpGet]
        [Route("user-login")]
        public ActionResult user_login()
        {
            return View();
        }

        [HttpPost]
        [Route("user-login")]
        public async Task<JsonResult> user_login(IFormCollection fcDegerler)
        {
            string strE_Posta = fcDegerler["e_posta"];
            string strSifre = fcDegerler["sifre"];
            byte bytDurum = 0;

            string strMesaj = string.Empty;

            if (string.IsNullOrEmpty(strE_Posta))
                strMesaj += "\n- Lütfen e-posta giriniz";

            if (string.IsNullOrEmpty(strSifre))
                strMesaj += "\n- Lütfen şifre giriniz";

            if (string.IsNullOrEmpty(strMesaj))
            {
                User kEf = new();
                kEf.Email = strE_Posta;
                kEf.Password = strSifre;

                EticaretDBContext context = new EticaretDBContext();
                UnitOfWork baglanti = new UnitOfWork(context);

                User sorgu = baglanti.IEFUsersRepository.fnLogin(kEf);
                if (sorgu == null)
                    strMesaj += "Kullanıcı bilgileri doğrulanamadı";
                else
                {
                    int? intKullanici_ID = sorgu.Id;
                    if (intKullanici_ID > 0)
                    {
                        byte[] bytUserId = Encoding.UTF8.GetBytes(sorgu.Id.ToString());
                        HttpContext.Session.Set("UserId", bytUserId);

                        byte[] bytEmail = Encoding.UTF8.GetBytes(sorgu.Email);
                        HttpContext.Session.Set("Email", bytEmail);

                        strMesaj += "Başarılı bir şekilde giriş yaptınız. Yönlendiriliyorsunuz.";
                        bytDurum = 1;

                        var clTalepler = new List<Claim>
                        {
                            new ("UserId", intKullanici_ID.ToString()),
                            new (ClaimTypes.NameIdentifier, sorgu.Email),
                            new (ClaimTypes.Email, sorgu.Email)
                        };

                        var ciTalepKimligi = new ClaimsIdentity(clTalepler, CookieAuthenticationDefaults.AuthenticationScheme);
                        var cpTalepEsas = new ClaimsPrincipal(ciTalepKimligi);
                        await HttpContext.SignInAsync(cpTalepEsas);

                    }
                }
            }

            clsJson json = new clsJson();
            json.basari_durumu = bytDurum;
            json.bilgi_mesaji = strMesaj;
            json.yonlendirilecek_adres = "/";

            return Json(json);
        }
        [HttpGet]
        [Route("user-logout")]
        [Authorize]
        public async Task<ActionResult> user_logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("user_login", "user");
        }
        public class clsJson
        {
            public int basari_durumu { get; set; }
            public string? bilgi_mesaji { get; set; }
            public string? yonlendirilecek_adres { get; set; }
        }
    }
}
