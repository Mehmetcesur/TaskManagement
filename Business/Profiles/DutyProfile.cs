using AutoMapper;
using Business.Dtos.Requests.DutyRequest;
using Business.Dtos.Responses.DutyResponse;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Business.Profiles
{
    public class DutyProfile : Profile
    {

        public DutyProfile()
        {
            CreateMap<CreateDutyRequest, Duty>();
            CreateMap<Duty, CreatedDutyResponse>();


            CreateMap<Duty, GetListDutyResponse>().ReverseMap();
            CreateMap<Paginate<Duty>, Paginate<GetListDutyResponse>>();

            CreateMap<UpdateDutyRequest, Duty>().ForMember(dest => dest.CreatedDate, opt => opt.Ignore());
            CreateMap<Duty, UpdatedDutyResponse>();
        }


    }
}
