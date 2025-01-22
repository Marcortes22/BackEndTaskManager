using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public string Id { get; set; }
        public string? givenName { get; set; }
        public string? familyName { get; set; }
        public string? nickname { get; set; }
        public string? wholeName { get; set; }
        public string? picture { get; set; }
        public DateTime? updatedAt { get; set; }
        public string? email { get; set; }
        public bool? emailVerified { get; set; }
        public string? provider { get; set; }
        public ICollection<TaskList> TaskLists { get; set; } = new List<TaskList>();
       


    }
}
