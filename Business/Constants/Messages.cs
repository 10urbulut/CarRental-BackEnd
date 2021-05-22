using Core.Entities.Concrete;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ContentAdded = "İçerik eklendi.";
        public static string ContentNameInvalid = "İsim geçersiz";
        public static string MaintenanceTime = "Sistem bakımda.";
        public static string ContentsListed = "İçerikler listelendi";
        public static string ContentDeleted = "İçerik silindi";
        public static string ContentUpdated = "İçerik güncellendi";
        public static string CarReturnError = "Araç henüz dönmemiş!";
        public static string CarCanHaveFiveImagesAtMost = "You can put up to five images ";
        public static string IdNotFound = " ID does not register ";
        public static string AuthorizationDenied = "Yetkilendirme reddedildi ";
        public static string UserRegistered = "Kullanıcı kaydedildi ";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası ";
        public static string SuccessfulLogin = "Giriş başarılı ";
        public static string UserAlreadyExists = "Kullanıcı zaten var ";
        public static string AccessTokenCreated = "Giriş jetonu oluşturuldu ";
    }
}
