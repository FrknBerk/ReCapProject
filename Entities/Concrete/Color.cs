using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Color:IEntity
    {
        [Key]
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public virtual List<Car> Cars { get; set; }
        ////Color(Renk) ile Cars(Araba) arasında bire çok ilişki var. Bu sebeple Color class ımıza Cars isimli property List olarak tanımlarız 
    }
}
