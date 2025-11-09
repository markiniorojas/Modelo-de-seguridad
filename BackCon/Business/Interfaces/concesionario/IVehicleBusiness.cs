using Business.Interfaces.Base;
using Entitys.Dtos.Request;
using Entitys.Dtos.Response;
using Entitys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Concesionario
{
    public interface IVehicleBusiness : IBaseBusiness<Vehicle, VehicleRequest, VehicleResponse>
    {
    }
}
