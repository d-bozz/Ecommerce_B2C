﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowers.DTO
{
    public class DashboardDTO
    {
        public string? TotalIngresos { get; set; }
        public int TotalVentas { get; set; }
        public int TotalClientes { get; set; }
        public int TotalProductos { get; set; }
    }
}
