using Business.Dtos.Requests.DutyRequest;
using Business.Dtos.Responses.DutyResponse;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Business.Abstracts
{
    public interface IDutyService
    {
        Task<CreatedDutyResponse> AddAsync(CreateDutyRequest createCompanyRequest);
        Task<UpdatedDutyResponse> UpdateAsync(UpdateDutyRequest updateDutyRequest);
        Task<Duty> DeleteAsync(int id);
        Task<IPaginate<GetListDutyResponse>> GetAllAsync(PageRequest pageRequest);
        Task<GetListDutyResponse> GetById(int id);



    }
}
