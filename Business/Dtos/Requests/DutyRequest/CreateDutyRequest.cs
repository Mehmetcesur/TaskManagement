using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Requests.DutyRequest
{
    public class CreateDutyRequest
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }
        public int UserId { get; set; }
    }
}
