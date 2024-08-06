using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Requests.DutyRequest
{
    public class UpdateDutyRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public DutyStatus Status { get; set; }
        public int UserId { get; set; }
    }
}
