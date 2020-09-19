﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Settings
{
    public interface IApiSettings
    {
        public string BaseAddress { get; set; }
        public string CatalogPath { get; set; }
        public string BasketPath { get; set; }
        public string OrderPath { get; set; }
    }
}
