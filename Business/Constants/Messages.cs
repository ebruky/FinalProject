using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
   public static class Messages
    {
        public static string Added = "Ekleme İşlemi Tamamlandı";
        public static string NameInvalid = "Verilen İsim Geçersiz.";
        public static string MaintenanceTime = "Bakım Zamanı";
        public static string ListAll = "Listeleme İşlemi Tamamlandı";
        public static string ListOfDesiredFeature = "İstenilen Özelliğe Göre Listeleme İşlemi";
        public static string ListOfRangePrice = "Verilen Fiyat Aralığına  Göre Listeleme İşlemi";
        public static string Details = "Detay";
        public static string GetById = "İstenilen";
        public static string Deleted = "Silme İşlemi Tamamlandı";
        public static string Uptated = "Güncelleme İşlemi Tamamlandı";
        public static string NotAdded = "Ekleme İşlemi Tamamlanamadı";
        public static string NotDeleted = "Silme İşlemi Tamamlanamadı";
        public static string NotUpdated = "Güncelleme İşlemi Tamamlanamadı";
        public static string AuthorizationDenied="Yetkiniz yok.";
        public static string UserRegistered = "Kullanıcı Kaydedildi";
        public static string AccessTokenCreated = "AccessToken Oluşturuldu";
        public static string UserAlreadyExists = "Kullanıcı zaten var";
        public static string SuccessfulLogin = "Başarı ile Giriş Yapıldı";
        public static string PasswordError = "Hatalı Şİfre";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
    }
}
