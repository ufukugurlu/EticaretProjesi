using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace Eticaret.Web.Classes
{
    public class Fonksiyonlar
    {
        public int intGosterim_Adeti = 15;
        public bool fnSayisal_Mi(object parVeri)
        {
            bool blnSonuc = false;
            if (parVeri != null)
            {
                string strVeri = parVeri.ToString();
                if (!string.IsNullOrEmpty(strVeri))
                {
                    Regex desen = new Regex("^[0-9]*$");
                    blnSonuc = desen.IsMatch(strVeri);
                }
            }
            return blnSonuc;
        }
        public byte[] ObjectToByteArray(Object obj)
        {
            if (obj == null)
                return null;

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);

            return ms.ToArray();
        }

        public T FromByteArray<T>(byte[] data)
        {
            if (data == null)
                return default(T);
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(data))
            {
                object obj = bf.Deserialize(ms);
                return (T)obj;
            }
        }
    }
}
