﻿using MVCSite.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSite.ViewModels
{
    public class CompanyViewModel
    {
        public IQueryable<Company> Companies { get; set; }
    }
}