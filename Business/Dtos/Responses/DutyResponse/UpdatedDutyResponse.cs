using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Responses.DutyResponse
{
    public class UpdatedDutyResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }
    }
}
