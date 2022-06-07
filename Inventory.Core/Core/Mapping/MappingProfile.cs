using AutoMapper;
using Inventory.Entities.DTOs;
using Inventory.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Core.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<ArticuloCreateDto, Articulo>();
            CreateMap<Articulo, ArticuloCreateDto>();
        }
    }
}
