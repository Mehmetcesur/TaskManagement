﻿using Core.DataAccess.Repositories;
using Core.Entities.Concretes;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class EfOperationClaimDal : EfRepositoryBase<OperationClaim, int, DutyManagementContext>, IOperationClaimDal
    {
        public EfOperationClaimDal(DutyManagementContext context) : base(context)
        {

        }
    }
}
