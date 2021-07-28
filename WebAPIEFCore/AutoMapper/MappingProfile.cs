using AutoMapper;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIEFCore.Models;

namespace WebAPIEFCore.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserSignUpResource, User>().ForMember(u => u.UserName, opt => opt.MapFrom(ur => ur.Email));
        }
    }
}
