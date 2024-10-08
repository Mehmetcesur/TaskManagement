﻿using Business.Dtos.Requests.UserRequest;
using Business.Dtos.Responses.UserResponse;
using Core.DataAccess.Paging;
using Core.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IUserService
    {
        Task<CreatedUserResponse> AddAsync(UserBase user);
        Task<UpdatedUserResponse> UpdateAsync(UpdateUserRequest updateUserRequest);
        Task<DeletedUserResponse> DeleteAsync(int id);
        Task<IPaginate<GetListUserResponse>> GetAllAsync(PageRequest pageRequest);
        Task<GetListUserResponse> GetById(int id);
        List<OperationClaim> GetClaims(UserBase user);
        Task<UserBase> GetByMail(string email);
        void Add(UserBase user);
    }
}
