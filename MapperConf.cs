using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TuSuperService.Models;

namespace TuSuperService.DTOS
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Clientes, ClientesDTO>().ReverseMap();      
            });
}
    }
}
