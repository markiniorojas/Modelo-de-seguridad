using Data.Implementacion.Base;
using Data.Interfaces.concesionario;
using Entitys.Context;
using Entitys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementacion.concesionario
{
    public class SaleData : DataGeneric<Sale>, ISaleData
    {
        public SaleData(ApplicationDbContext context) : base(context) { }
    }
}
