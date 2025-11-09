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
    public class SaleDetailsBusiness: BaseBusiness<SaleDetails, SaleDetailRequest, SaleDetailResponse>
    {
        public SaleDetailsBusiness(ABaseData<SaleDetails> data, IMapper mapper) 
            : base(data, mapper) 
        { 
        }

    }
}
