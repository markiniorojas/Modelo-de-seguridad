using Data.Implementacion.Base;
using Data.Interfaces.Base;
using Data.Interfaces.concesionario;
using Entitys.Context;
using Entitys.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementacion.concesionario
{
    public class ClientData : DataGeneric<Client>, IClientData
    {
        public ClientData(ApplicationDbContext context) : base(context) { }

        public async Task<Client?> GetByDocumentoAsync(string documento)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.Document == documento && !c.IsDeleted);
       }

    }
}
