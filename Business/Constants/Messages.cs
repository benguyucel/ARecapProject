using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string UserAdded = "Ürün Eklendi";

        public static string UsersListed = "Kullanıclar Listelendi";

        public static string AlreadyRent = "Araç Zaten Kirada";

        public static string CarRented = "Araç Kiralandı";

        public static string ImageLimit = "Bir araba için en fazla 5 adet resim yüklenebilir";

        public static string ImageUpload = "Fotograf Yüklendi";

        public static string UserNotFound = "Kullanıcı Bulunamadı";

        public static string PasswordError = "Şifre hatalı";

        public static string SuccessfullLogin = "Giriş başarılı";

        public static string UserRegistered = "Kullanıcı kaydedildi";

        public static string AuthorizationDenied = "Yetki reddedildi";
    }
}
