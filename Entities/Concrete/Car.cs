using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Car:IEntity
    {
        [Key]//Veritabanında Primary Key denk geliyor
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }

        public virtual Brand Brand { get; set; }
        //Her Cars(Araba) ın bir Brand(Marka) olacaktır.Cars class ile Brand class arasında ilişki kuruyoruz. Brand isimli bir class oluşturuyoruz.
        public virtual Color Color { get; set; }
        //Her Cars(Araba) ın bir Color(Renk) olacaktır.Cars class ile Color class arasında ilişki kuruyoruz. Color isimli bir class oluşturuyoruz.
    }
}
