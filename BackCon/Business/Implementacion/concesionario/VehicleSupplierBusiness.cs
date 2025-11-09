using AutoMapper;
using Business.Implementacion.Base;
using Data.Interfaces.Base;
using Entitys.Dtos.Request;
using Entitys.Dtos.Response;
using Entitys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementacion.Concesionario
{
    public class VehicleSupplierBusiness : BaseBusiness<VehicleSupplier, VehicleSupplierRequest, VehicleSupplierResponse>
    {
        public VehicleSupplierBusiness(ABaseData<VehicleSupplier> data, IMapper mapper) 
            : base(data, mapper)
        {
        }
    }
}
