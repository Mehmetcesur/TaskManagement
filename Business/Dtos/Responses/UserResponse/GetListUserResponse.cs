
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Responses.UserResponse
{
    public class GetListUserResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

    }
}