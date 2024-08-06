using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AutoMapper;
using Entities.Concretes;
using Core.DataAccess.Paging;
using Business.Dtos.Requests.UserRequest;
using Business.Dtos.Responses.UserResponse;
using Core.Entities.Concretes;

namespace Business.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserForLoginRequest, User>();
            CreateMap<User, CreatedUserResponse>();
            CreateMap<CreatedUserResponse, UserBase>();
            CreateMap<UserBase, User>().ReverseMap();

            CreateMap<User, DeletedUserResponse>().ReverseMap();

            CreateMap<User, GetListUserResponse>().ReverseMap();

            CreateMap<Paginate<User>, Paginate<GetListUserResponse>>();

            CreateMap<UpdateUserRequest, User>().ForMember(dest => dest.CreatedDate, opt => opt.Ignore());
            CreateMap<User, UpdatedUserResponse>();
        }
    }
}
