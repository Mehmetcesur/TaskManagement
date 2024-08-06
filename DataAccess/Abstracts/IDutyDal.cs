using Core.DataAccess.Repositories;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;


namespace DataAccess.Abstracts
{
    public interface IDutyDal : IRepository<Duty, int>, IAsyncRepository<Duty, int>
    {
    }
}
