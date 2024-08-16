using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.DutyRequest;
using Business.Dtos.Responses.DutyResponse;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class DutyManager : IDutyService

    {

        IDutyDal _dutyDal;
        IMapper _mapper;

        public DutyManager(IDutyDal dutyDal, IMapper mapper)
        {
            _dutyDal = dutyDal;
            _mapper = mapper;
        }


        public async Task<CreatedDutyResponse> AddAsync(CreateDutyRequest createCompanyRequest)
        {
            Duty duty = _mapper.Map<Duty>(createCompanyRequest);
            Duty createdDuty = await _dutyDal.AddAsync(duty);

            CreatedDutyResponse createdDutyResponse = _mapper.Map<CreatedDutyResponse>(createdDuty);
            return createdDutyResponse;

        }

        public async Task<Duty> DeleteAsync(int id)
        {
            var data = await _dutyDal.GetAsync(i => i.Id == id);
            var result = await _dutyDal.DeleteAsync(data);
            return result;
        }

        public async Task<IPaginate<GetListDutyResponse>> GetAllAsync(PageRequest pageRequest)
        {
            var data = await _dutyDal.GetListAsync(
                include: p => p.Include(p => p.User),

                index: pageRequest.PageIndex,
                size: pageRequest.PageSize


                );
            var result = _mapper.Map<Paginate<GetListDutyResponse>>(data);
            return result;
        }

        public async Task<GetListDutyResponse> GetById(int id)
        {
            var data = await _dutyDal.GetAsync(d => d.Id == id);
            var result = _mapper.Map<GetListDutyResponse>(data);
            return result;
        }

        public async Task<IPaginate<GetByUserIdDutyResponse>> GetByUserIdAsync(PageRequest pageRequest, int userId)
        {
            var data = await _dutyDal.GetListAsync(
                include: e => e.Include(c => c.User),
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize,
                predicate: p => p.UserId == userId
                );
            var result = _mapper.Map<Paginate<GetByUserIdDutyResponse>>(data);

            return result;

        }

        public async Task<UpdatedDutyResponse> UpdateAsync(UpdateDutyRequest updateDutyRequest)
        {
            var data = await _dutyDal.GetAsync(i => i.Id == updateDutyRequest.Id);
            _mapper.Map(updateDutyRequest, data);
            data.UpdatedDate = DateTime.Now;
            await _dutyDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedDutyResponse>(data);
            return result;
        }
    }
}
