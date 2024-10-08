﻿using Business.Dtos.Requests.OperationClaimRequests;
using Business.Dtos.Responses.OperationClaimResponse;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IOperationClaimService
    {
        Task<CreatedOperationClaimResponse> AddAsync(CreateOperationClaimRequest createOperationClaimRequest);
        Task<UpdatedOperationClaimResponse> UpdateAsync(UpdateOperationClaimRequest updateOperationClaimRequest);
        Task<DeletedOperationClaimResponse> DeleteAsync(int id);
        Task<IPaginate<GetListOperationClaimResponse>> GetListAsync(PageRequest pageRequest);

    }
}
