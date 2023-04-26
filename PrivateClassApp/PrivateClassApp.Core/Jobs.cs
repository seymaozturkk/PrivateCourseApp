using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Core
{
    public static class Jobs
    {
        public static string GetUrl(string text)
        {
            #region Sorunlu Türkçe Karakterler Düzeltiliyor
            text = text.Replace("I", "i");
            text = text.Replace("İ", "i");
            text = text.Replace("ı", "i");
            #endregion
            #region Küçük Harfe Dönüştürülüyor
            text = text.ToLower();
            #endregion
            #region Türkçe Karakterler Düzeltiliyor
            text = text.Replace("ö", "o");
            text = text.Replace("ü", "u");
            text = text.Replace("ş", "s");
            text = text.Replace("ç", "c");
            text = text.Replace("ğ", "g");
            #endregion
            #region Sorunlu Karakterler Düzeltiliyor
            text = text.Replace(".", "");
            text = text.Replace("/", "");
            text = text.Replace("\\", "");
            text = text.Replace("'", "");
            text = text.Replace("`", "");
            text = text.Replace("\"", "");
            text = text.Replace("(", "");
            text = text.Replace(")", "");
            text = text.Replace("{", "");
            text = text.Replace("}", "");
            text = text.Replace("[", "");
            text = text.Replace("]", "");
            text = text.Replace("?", "");
            text = text.Replace(",", "");
            text = text.Replace("-", "");
            text = text.Replace("_", "");
            text = text.Replace("$", "");
            text = text.Replace("&", "");
            text = text.Replace("%", "");
            text = text.Replace("^", "");
            text = text.Replace("#", "");
            text = text.Replace("+", "");
            text = text.Replace("!", "");
            text = text.Replace("=", "");
            text = text.Replace(";", "");
            text = text.Replace(">", "");
            text = text.Replace("<", "");
            text = text.Replace("|", "");
            text = text.Replace("*", "");

            #endregion
            #region Boşluklar Tire İle Değiştiriliyor
            text = text.Replace(" ", "-");
            #endregion
            return text;
        }
        public static string NormalizedName(string text)
        {
            #region Sorunlu Türkçe Karakterler Düzeltiliyor
            text = text.Replace("I", "i");
            text = text.Replace("İ", "i");
            text = text.Replace("ı", "i");
            #endregion
            #region Büyük Harfe Dönüştürülüyor
            text = text.ToUpper();
            #endregion
            #region Türkçe Karakterler Düzeltiliyor
            text = text.Replace("ö", "o");
            text = text.Replace("ü", "u");
            text = text.Replace("ş", "s");
            text = text.Replace("ç", "c");
            text = text.Replace("ğ", "g");
            #endregion
            #region Sorunlu Karakterler Düzeltiliyor
            text = text.Replace("/", "");
            text = text.Replace("@", "");
            text = text.Replace("\\", "");
            text = text.Replace("'", "");
            text = text.Replace("`", "");
            text = text.Replace("\"", "");
            text = text.Replace("(", "");
            text = text.Replace(")", "");
            text = text.Replace("{", "");
            text = text.Replace("}", "");
            text = text.Replace("[", "");
            text = text.Replace("]", "");
            text = text.Replace("?", "");
            text = text.Replace(",", "");
            text = text.Replace("$", "");
            text = text.Replace("&", "");
            text = text.Replace("%", "");
            text = text.Replace("^", "");
            text = text.Replace("#", "");
            text = text.Replace("+", "");
            text = text.Replace("!", "");
            text = text.Replace("=", "");
            text = text.Replace(";", "");
            text = text.Replace(">", "");
            text = text.Replace("<", "");
            text = text.Replace("|", "");
            text = text.Replace("*", "");

            #endregion
            #region Boşluklar Kaldırılıyor
            text = text.Replace(" ", "");
            #endregion
            return text;
        }
        public static string NormalizedEmail(string text)
        {
            #region Sorunlu Türkçe Karakterler Düzeltiliyor
            text = text.Replace("I", "i");
            text = text.Replace("İ", "i");
            text = text.Replace("ı", "i");
            #endregion
            #region Büyük Harfe Dönüştürülüyor
            text = text.ToUpper();
            #endregion
            #region Türkçe Karakterler Düzeltiliyor
            text = text.Replace("ö", "o");
            text = text.Replace("ü", "u");
            text = text.Replace("ş", "s");
            text = text.Replace("ç", "c");
            text = text.Replace("ğ", "g");
            #endregion
            #region Sorunlu Karakterler Düzeltiliyor
            text = text.Replace("/", "");
            text = text.Replace("\\", "");
            text = text.Replace("'", "");
            text = text.Replace("`", "");
            text = text.Replace("\"", "");
            text = text.Replace("(", "");
            text = text.Replace(")", "");
            text = text.Replace("{", "");
            text = text.Replace("}", "");
            text = text.Replace("[", "");
            text = text.Replace("]", "");
            text = text.Replace("?", "");
            text = text.Replace(",", "");
            text = text.Replace("$", "");
            text = text.Replace("&", "");
            text = text.Replace("%", "");
            text = text.Replace("^", "");
            text = text.Replace("#", "");
            text = text.Replace("+", "");
            text = text.Replace("!", "");
            text = text.Replace("=", "");
            text = text.Replace(";", "");
            text = text.Replace(">", "");
            text = text.Replace("<", "");
            text = text.Replace("|", "");
            text = text.Replace("*", "");

            #endregion
            #region Boşluklar Kaldırılıyor
            text = text.Replace(" ", "");
            #endregion
            return text;
        }
    }
}
