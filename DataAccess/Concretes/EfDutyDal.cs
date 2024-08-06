using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;


namespace DataAccess.Concretes
{
    public class EfDutyDal : EfRepositoryBase<Duty, int, DutyManagementContext>, IDutyDal
    {
        public EfDutyDal(DutyManagementContext context) : base(context)
        {
        }
    }
}
