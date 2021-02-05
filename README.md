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

  -Brand-->Id,Name

  -Color-->Id,Name

- Sql Server tarafında yeni bir veritabanı kurunuz. **Cars**,**Brands**,**Colors** tablolarını oluşturunuz. (Araştırma)

- Sisteme Generic **IEntityRepository** altyapısı yazınız.

- **Car**, **Brand** ve **Color** nesneleri için Entity Framework altyapısını yazınız.

- **GetCarsByBrandId** , **GetCarsByColorId** servislerini yazınız.

- Sisteme yeni araba eklendiğinde aşağıdaki kuralları çalıştırınız.

  -Araba ismi minimum 2 karakter olmalıdır

  -Araba günlük fiyatı 0'dan büyük olmalıdır.
  

