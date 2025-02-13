using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskLists.Queries.GetTaskListInformation.Response
{
    public class GetTaskListInformationResponse
    {
        public string Name { get; set; }

        public int amoundOfTasks { get; set; }

        public string url { get; set; }

        public bool? isDefault { get; set; }
        
        public int? Id { get; set; }
    }
}
