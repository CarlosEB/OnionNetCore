using OnionNetCore.Core.DTOs;
using OnionNetCore.Core.Entities;

namespace OnionNetCore.Core.Mapper
{
    public class AutoMapperApp
    {
        public static void ConfigureAutoMapper()
        {
            AutoMapper.Mapper.Initialize(cfg => {
                cfg.CreateMap<User, UserResponse>();
                cfg.CreateMap<UserRequest, User>();
            });
        }
    }
}