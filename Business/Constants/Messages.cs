
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string ProductsListed ="Ürünler listelendi";
        public static string ProductCountOfCategoryError="Bir kategoride en fazla 10 ürün olabilir";
        public static string ProductNameAlreadyExists="Bu isimde zaten başka bir ürün var";
        public static string CategoryLimitExceded = "Kategori limiti aşıldığı için yeni ürün eklenemiyor";
        public static string AddressListed = "Adresler listelendi";
        public static string AddressFilterCityId="Şehire göre adresler listelendi";
        public static string AddressAdded="Adres eklendi";
        public static string AddressDeleted="Adres silindi";
        public static string AddressUpdated="Adres güncellendi";
        public static string MaintenanceTime="Bakımda.";
        public static string CategoryAdded = "Kategori eklendi";
        public static string UserAdded="Kullanıcı eklendi";
        public static string UserDeleted="Kullanıcı silindi";
        public static string UserUpdated="Kullanıcı güncellendi";
        public static string PictureInvalid="Bir ürüne en fazla 5 tane resim eklenebilir.";
        public static string ImagesAdded="Resim eklendi.";
        public static string FailAddedImageLimit = "Resim limitine erişildi!";
        public static string CarImageLimitExceeded="Arabaya resim ekleme limitine ulaşıldı";
        public static string UserNotFound="Kullanıcı bulunamadı.";
        public static string PasswordError="Parola hatası.";
        public static string SuccessfulLogin="Giriş başarılı";
        public static string UserAlreadyExist="Bu kullanıcı zaten mevcut";
        public static string UserRegistered="Kullanıcı başarıyla kaydedildi.";
        public static string AccessTokenCreated="Access Token başarıyla oluşturuldu";
        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string AddedBasket="Sepete eklendi";
        public static string DeletedBasket="Sepetten silindi";
        public static string UpdatedBasket="Ürün güncellendi";
        public static string AddedOrder="Sipariş başarılı";
        public static string DeletedOrder="Sipariş silindi";
        public static string UpdatedOrder="Sipariş güncellendi";
        public static string AddedComment="Yorum başarılı";
        public static string DeletedComment="Yorum silindi";
        public static string UpdatedComment="Yorum güncellendi";
        public static string ProductDeleted="Ürün silindi";
        public static string ProductUpdated="Ürün güncellendi";
    }
}
