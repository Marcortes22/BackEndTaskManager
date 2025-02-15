using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Auth0.Dto
{
    public class UserInfoDto
    {
        public string sub { get; set; }

        public string? given_name { get; set; }
        public string? family_name { get; set; }
        public string? nickname { get; set; }
        public string? name { get; set; }
        public string? picture { get; set; }
        public DateTime? updated_at { get; set; }
        public string? email { get; set; }
        public bool? email_verified { get; set; }
        public string? provider { get; set; }
    }
}


