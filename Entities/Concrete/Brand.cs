﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class Brand:IEntity
    {
        //MODEL ADINDA BİR TABLO OLUŞTURUP BRAND IN MODELLERİ OLACAK CAR TABLOSUNDA MODEL OLACAK
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public bool GetState { get; set; }
    }
}
