using Data.Interfaces.Base;
using Entitys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces.concesionario
{
    public interface IClientData : ABaseData<Client>
    {
        Task<Client?> GetByDocumentoAsync(string documento);
    }
}
