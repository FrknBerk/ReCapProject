using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarDeleted = "Araba silindi";
        public static string CarUpdated = "Araba güncellendi";

        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorList = "Renkler";
        public static string ColorNameExists = "Aynı isim renk vardır";

        public static string BrandAdded = "Marka Eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdate = "Marka güncellendi";
        public static string BrandAddedError = "Aynı isimde marka var";

        public static string UserAdded = "Kullanıcı Eklendi";
        public static string UserDeleted = "Kullanıcı Silindi";
        public static string UserUpdated = "Kullanıcı Güncellendi";
        public static string UserListed = "Kullanıcılar Listelendi";
        public static string UserAddedError = "Böyle bir email var şifrenizi mi unuttunuz";

        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted = "Müşteri Silindi";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string CustomerListed = "Müşteri listelendi";

        public static string RentalDeleted = "Kiralık Araba silindi";
        public static string RentalUpdated = "Kiralık araba güncellendi";
        public static string RentalListed = "Kiralık arabalar listelendi";

        public static string RentalAdded = "Araba başarıyla kiralandı";
        public static string RentalDate = "Teslim edilmemiş arabayı kiralayamassınız";
        public static string RentalSuccesAdded = "Bu araç kiralanabilir";

        public static string ProductInvalidName = "Description 2 karakterden fazla ve Dailyprice 0 dan büyük olmalı";
        public static string CarList = "Car List";
        public static string CompanyNameExists="Aynı isimde şirket adı var!";

        public static string CarImageLimited="Araba resmi 5 den fazla olamaz";
        public static string CarImageAdded="Araba resmi başarıyla eklendi";
        public static string CarImageList="Araba resimleri listelendi";
        public static string CarImageUpdated="Araba resmi güncellendi";
        public static string CarImageDeleted="Araba resmi silindi";
        public static string CarIdImageExists="Araba resmi yok";
    }
}
