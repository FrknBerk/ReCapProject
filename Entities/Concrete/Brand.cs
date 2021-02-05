using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Brand:IEntity
    {
        [Key]
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public virtual List<Car> Cars { get; set; }
        //Brand(Marka) ile Cars(Araba) arasında bire çok ilişki var. Bu sebeple Brand class ımıza Cars isimli property List olarak tanımlarız 
    }
}
