
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
         public static string CarAdded = "Araba eklendi";
        public static string DailyPriceInvalid = "Arabanın günlük fiyatı 0 olamaz";
        public static string CarNameInvalid = "Araba ismi geçersiz";
        public static string MaintenanceTime="Bakımda.";
        public static string CategoryAdded = "Kategori eklendi";
        public static string ColorAdded="Renk eklendi";
        public static string RentalAddedError="Araba şuan mevcut değil";
        public static string CarDeleted="Araba silindi";
        public static string CarUpdate="Araba güncellendi";
        public static string BrandAdded="Marka Eklendi";
        public static string BrandNameInvalid="Marka ismi en az 2 karakterden oluşmalıdır";
        public static string BrandUpdated="Marka güncellendi";
        public static string BrandDeleted="Marka silindi";
        public static string ColorDeleted="Renk silindi";
        public static string ColorUpdated="Renk güncellendi";
        public static string ColorNameInvalid="Renk ismi en az 2 karakterden oluşmalıdır";
        public static string UserAdded="Kullanıcı eklendi";
        public static string UserDeleted="Kullanıcı silindi";
        public static string UserUpdated="Kullanıcı güncellendi";
        public static string CustomerAdded="Müşteri eklendi";
        public static string CustomerDeleted="Müşteri silindi";
        public static string CustomerUpdated="Müşteri güncellendi";
        public static string CategoryDeleted="Kategori silindi";
        public static string CategoryUpdated="Kategori güncellendi";
        public static string RentalDeleted="Kiralama silindi";
        public static string RentalUpdated="Kiralama güncellendi";
        public static string PictureInvalid="Bir arabaya en fazla 5 tane resim eklenebilir.";
        public static string EditCarImageMessage= "Araç resmi başarıyla güncellendi";
        public static string AddCarImageMessage="Araç resmi başarıyla eklendi";
        public static string DeleteCarImageMessage="Araç resmi başarıyla silindi";
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
        public static string CarListed="Arabalar listelendi";
        public static string FindeksAdded="Findeks eklendi";
        public static string FindeksDeleted="Findeks güncellendi";
        public static string FindeksUpdated="Findeks silindi";
        public static string CarFindeksAdded="Araba findeks eklendi";
        public static string CarFindeksDeleted="Araba findeks silindi";
        public static string CarFindeksUpdated="Araba findeks güncellendi";
        public static string FindeksScoreMax="Findeks skoru 1900 den büyük olamaz";
        public static string FindeksScoreSuccesful="Başarılı";
        public static string AddedBasket="Sepete eklendi";
        public static string DeletedBasket="Sepetten silindi";
        public static string UpdatedBasket="Ürün güncellendi";
        public static string AddedOrder="Sipariş başarılı";
        public static string DeletedOrder;
        public static string UpdatedOrder;
    }
}
