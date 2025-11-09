using AutoMapper;
using Entitys.Dtos.Request;
using Entitys.Dtos.Response;
using Entitys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // CLIENT
            CreateMap<Client, ClientResponse>();
            CreateMap<ClientRequest, Client>();

            // VEHICLE
            CreateMap<Vehicle, VehicleResponse>();
            CreateMap<VehicleRequest, Vehicle>();

            // SELLER
            CreateMap<Seller, SellerResponse>();
            CreateMap<SellerRequest, Seller>();

            // PROVIDER
            CreateMap<Supplier, SupplierResponse>();
            CreateMap<SupplierRequest, Supplier>();

            // SALE
            CreateMap<Sale, SaleResponse>();
            CreateMap<SaleRequest, Sale>();

            // SALE DETAIL
            CreateMap<SaleDetails, SaleDetailResponse>();
            CreateMap<SaleDetailRequest, SaleDetails>();
        }
    }
}
