using Microsoft.AspNetCore.Http;
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
        public static string UploadTeacherImage(IFormFile image)
        {
            var extension = Path.GetExtension(image.FileName);
            var randomName = $"{Guid.NewGuid()}{extension}";
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Teachers", randomName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                image.CopyTo(stream);
            }

            return randomName;
        }
        public static string UploadStudentImage(IFormFile image)
        {
            var extension = Path.GetExtension(image.FileName);
            var randomName = $"{Guid.NewGuid()}{extension}";
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Students", randomName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                image.CopyTo(stream);
            }

            return randomName;
        }
        public static string GetZoomLink()
        {
            string baseLink = "https://zoom.us/j/";
            string apiKey = "abcdefghijklmnopqrstuvwxyz1234567890";

            string meetingId = "1234567890";
            string password = "1234567890";

            string zoomLink = baseLink + apiKey + "?pwd=" + password + "&id=" + meetingId;
            return zoomLink;
        }
    }
}
