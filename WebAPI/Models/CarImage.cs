﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class CarImage
    {
        public IFormFile Files { get; set; }
        public int CarId { get; set; }
    }
}
