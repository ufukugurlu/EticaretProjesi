function fnSepete_Ekle(strUrunId, strUrunAdi) {
    var xhrIstek = new XMLHttpRequest();
    var strAjaxAdres = '/ajax/sepete-ekle';
    var strAjaxParametreler = 'urunid=' + strUrunId + '&urunadi=' + strUrunAdi;
    xhrIstek.open('POST', strAjaxAdres, true);
    xhrIstek.setRequestHeader('Content-type', 'application/x-www-form-urlencoded;charset=ISO-8859-1');
    xhrIstek.onreadystatechange = function () {
        if (xhrIstek.readyState == 4) {
            if (xhrIstek.status == 200) {
                var strSonuc = xhrIstek.responseText;
                alert(strSonuc);
            }
            else {
                var strHataMesaji = "Bir hata oluştu. Hata detayları: ";
                strHataMesaji += "\nxhrIstek.status: " + xhrIstek.status;
                strHataMesaji += "\nxhrIstek.responseText: " + xhrIstek.responseText;
                console.log("hata", strHataMesaji);
            }
        }
    }
    xhrIstek.send(strAjaxParametreler);
}


var btnKullanici_Giris = document.querySelector('.js-button-kullanici-giris');
if (btnKullanici_Giris != null) {
    btnKullanici_Giris.addEventListener("click", function (event) {
        var strE_Posta = document.querySelector('.js-input-e-posta').value;
        var strSifre = document.querySelector('.js-input-sifre').value;
        var xhrIstek = new XMLHttpRequest();
        var strAjaxAdres = '/user-login';
        var strAjaxParametreler = 'e_posta=' + strE_Posta + '&sifre=' + strSifre;
        xhrIstek.open('POST', strAjaxAdres, true);
        xhrIstek.setRequestHeader('Content-type', 'application/x-www-form-urlencoded;charset=ISO-8859-1');
        xhrIstek.onreadystatechange = function () {
            if (xhrIstek.readyState == 4) {
                if (xhrIstek.status == 200) {
                    var jsonSonuc = JSON.parse(xhrIstek.responseText);
                    if (jsonSonuc == null || jsonSonuc == '') {
                        alert('JSON sonuç değeri null olamaz');
                    }
                    else {
                        alert(jsonSonuc.bilgi_mesaji);
                        if (jsonSonuc.basari_durumu == '1') {
                            if (jsonSonuc.yonlendirilecek_adres !== '') {
                                setTimeout(function () { window.location.href = jsonSonuc.yonlendirilecek_adres; }, 2500);
                            }
                        }
                    }
                }
                else {
                    var strHataMesaji = "Bir hata oluştu. Hata detayları: ";
                    strHataMesaji += "\nxhrIstek.status: " + xhrIstek.status;
                    strHataMesaji += "\nxhrIstek.responseText: " + xhrIstek.responseText;
                    console.log("hata", strHataMesaji);
                }
            }
        }
        xhrIstek.send(strAjaxParametreler);
    });
}
