using AutoMapper;
using Prog3.Models.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prog3.Models.Mappings
{
    public class AutoMapperProfile: Profile
    {

        public AutoMapperProfile()
        {

            CreateMap<Producto, ProductViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(o => o.IdProducto))
                .ForMember(x => x.Codigo, opt => opt.MapFrom(o => o.CodigoProducto))
                .ForMember(x => x.Nombre, opt => opt.MapFrom(o => o.NombreProducto))
                .ForMember(x => x.Tipo, opt => opt.MapFrom(o => o.IdTipoProductoNavigation.NombreTipo))
                .ForMember(x => x.Stock, opt => opt.MapFrom(o => o.Stock))
                .ForMember(x => x.Precio, opt => opt.MapFrom(o => o.Precio))
                .ForMember(x => x.Imagen, opt => opt.MapFrom(o => o.Imagen));

            CreateMap<Producto, ProductCreateOrUpdateData>()
                .ForMember(x => x.idProducto, opt => opt.MapFrom(o => o.IdProducto))
                .ForMember(x => x.Codigo, opt => opt.MapFrom(o => o.CodigoProducto))
                .ForMember(x => x.Nombre, opt => opt.MapFrom(o => o.NombreProducto))
                .ForMember(x => x.TipoProducto, opt => opt.MapFrom(o => o.IdTipoProductoNavigation.NombreTipo))
                .ForMember(x => x.Stock, opt => opt.MapFrom(o => o.Stock))
                .ForMember(x => x.Precio, opt => opt.MapFrom(o => o.Precio))
                .ForMember(x => x.Imagen, opt => opt.MapFrom(o => o.Imagen));

            CreateMap<Producto, ProductLiteDTO>()
                .ForMember(x => x.Codigo, opt => opt.MapFrom(o => o.CodigoProducto))
                .ForMember(x => x.Nombre, opt => opt.MapFrom(o => o.NombreProducto));

            CreateMap<Persona, PersonaViewModel>()
                .ForMember(x => x.Nombre, opt => opt.MapFrom(o => o.Nombre))
                .ForMember(x => x.Apellido, opt => opt.MapFrom(o => o.Apellido))
                .ForMember(x => x.Razon, opt => opt.MapFrom(o => o.RazonSocial));

            CreateMap<Direccion, DireccionViewModel>()
                .ForMember(x => x.Nombre, opt => opt.MapFrom(o => o.IdPersonaNavigation.Nombre))
                .ForMember(x => x.Apellido, opt => opt.MapFrom(o => o.IdPersonaNavigation.Apellido))
                .ForMember(x => x.Razon, opt => opt.MapFrom(o => o.IdPersonaNavigation.RazonSocial))
                .ForMember(x => x.Provincia, opt => opt.MapFrom(o => o.Provincia))
                .ForMember(x => x.Ciudad, opt => opt.MapFrom(o => o.Ciudad))
                .ForMember(x => x.Calle, opt => opt.MapFrom(o => o.Calle))
                .ForMember(x => x.NumeroCalle, opt => opt.MapFrom(o => o.NumeroCalle));

            CreateMap<Cliente, ClienteViewModel>()
                .ForMember(x => x.Nombre, opt => opt.MapFrom(o => o.IdPersonaNavigation.Nombre))
                .ForMember(x => x.Apellido, opt => opt.MapFrom(o => o.IdPersonaNavigation.Apellido))
                .ForMember(x => x.Razon, opt => opt.MapFrom(o => o.IdPersonaNavigation.RazonSocial));
        }

    }
}
