﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Brand:IEntity
    {
        //MODEL ADINDA BİR TABLO OLUŞTURUP BRAND IN MODELLERİ OLACAK CAR TABLOSUNDA MODEL OLACAK
        [Key]
        public int BrandId { get; set; }
        [StringLength(50)]
        public string BrandName { get; set; }
        public bool State { get; set; }
        public virtual List<Car> Cars { get; set; }
        //Brand(Marka) ile Cars(Araba) arasında bire çok ilişki var. Bu sebeple Brand class ımıza Cars isimli property List olarak tanımlarız 
    }
}
