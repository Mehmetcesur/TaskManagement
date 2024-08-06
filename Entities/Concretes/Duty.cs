using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Duty :Entity<int>
    {
        public int UserId { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public User User { get; set; }

    }
}
