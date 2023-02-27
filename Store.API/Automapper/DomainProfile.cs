using AutoMapper;
using Store.Domain.Dtos;
using System;

namespace Store.API.Automapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateTwoWayMap<Domain.Models.User, User>();
        }

        public void CreateTwoWayMap<T1, T2>()
        {
            CreateMap<T1, T2>();
            CreateMap<T2, T1>();
        }

        public void CreateTwoWayMap(Type t1, Type t2)
        {
            CreateMap(t1, t2);
            CreateMap(t2, t1);
        }
    }
}
