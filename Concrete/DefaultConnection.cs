﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buttons.Domain.Entities;
using System.Data.Entity;

namespace Buttons.Domain.Concrete
{
    public class DefaultConnection : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
