﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class ResponseDTO<T>
    {
        public T? Result { get; set; }
        public bool IsCorrect { get; set; }
        public string? Message { get; set; }
    }
}
