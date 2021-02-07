# ReCapProject
Araç Kiralama Projesi

## Proje Detayları
Yepyeni bir proje oluşturunuz. Adı **ReCapProject** olacak.

**Entities**, **DataAccess**, **Business** ve **Console** **katmanlarını** oluşturunuz.

Bir araba nesnesi oluşturunuz. **"Car"**

Özellik olarak : **Id**, **BrandId**, **ColorId**, **ModelYear**, **DailyPrice**, **Description** alanlarını ekleyiniz. (Brand = Marka)

**InMemory** formatta **GetById**, **GetAll**, **Add**, **Update**, **Delete** oprasyonlarını yazınız.

Consolda test ediniz.

## Projeye Devam
Araba Kiralama projemiz üzerinde çalışmaya devam edeceğiz.

**Car** nesnesine ek olarak;

- **Brand** ve **Color** nesneleri ekleyiniz(Entity)

  1.Brand-->Id,Name

  2.Color-->Id,Name

- Sql Server tarafında yeni bir veritabanı kurunuz. **Cars**,**Brands**,**Colors** tablolarını oluşturunuz. (Araştırma)

- Sisteme Generic **IEntityRepository** altyapısı yazınız.

- **Car**, **Brand** ve **Color** nesneleri için Entity Framework altyapısını yazınız.

- **GetCarsByBrandId** , **GetCarsByColorId** servislerini yazınız.

- Sisteme yeni araba eklendiğinde aşağıdaki kuralları çalıştırınız.

  1.Araba ismi minimum 2 karakter olmalıdır

  2.Araba günlük fiyatı 0'dan büyük olmalıdır.
  
###### Veritabanı İşlemleri
**Entity Framework:** .Net platformunda ORM(Object Relational Mapping) araçlarından birisidir. ORM (Object Relational Mapping) ise veritabanı ile nesneye yönelik programlama (OOP) arasındaki ilişkiyi kuran teknolojidir. Yani Entity Framework, nesne tabanlı programlamada veritabanındaki tablolara uygun nesneler oluşturma tekniğidir.
Entity Framework ile 3 farklı yöntem ile proje geliştirilebilir. Bu yöntemler;
- Model First (New Database)
- Database First (Existing Database)
- Code First (New Database)

Biz bu yöntemlerden **Code First** ile ilgileneceğiz.
Code First, adından da anlaşılacağı üzere kod ile veritabanı ve entity modeli tasarlama yaklaşımıdır. 
Yapmanız gereken tek şey kodlarla entity classlarını tanımlamak olacaktır.

DataAccess Class Library(.Net Standard) projesine sağ tıklayıp **Manage Nuget Packages**  diyoruz **Browse** da **Microsoft.EntityFrameworkCore.SqlServer** 3.1.11 versiyonu ve **Microsoft.EntityFrameworkCore.Tools** 3.1.11 versiyonlarını indiyoruz

ConsoleUI Class Library(.Net Standart) projesine sağ tıklayıp **Manage Nuget Packages** diyoruz **Browse** da **Microsoft.EntityFrameworkCore.Design** 3.1.11 veriyonunu indiriyoruz

**Tools->Manage Nuget Packages->Package Manager Console** açıyoruz ve
```
Add-Migration RentaCar
```
RentaCar veritabanı ismimi RentaCar yerine başka isimler verebilirsiniz

```
update-database
``` 
ile veritabanımızı güncelliyoruz

## Projeye Devam

-CarRental Projenizde **Core** katmanı oluşturunuz.

-**IEntity**, **IDto**, **IEntityRepository**, **EfEntityRepositoryBase** dosyalarınızı 9. gün dersindeki gibi oluşturup ekleyiniz.

-**Car**, **Brand**, **Color** sınıflarınız için tüm CRUD operasyonlarını hazır hale getiriniz.

-Console'da Tüm CRUD operasyonlarınızı **Car, Brand, Model** nesneleriniz için test ediniz. **GetAll, GetById, Insert, Update, Delete**.

-Arabaları şu bilgiler olacak şekilde listeleyiniz. **CarName**, **BrandName**, **ColorName**, **DailyPrice**. >(İpucu : IDto oluşturup 3 tabloya join yazınız)
