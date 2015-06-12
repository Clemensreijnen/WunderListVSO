using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCTEST.Models
{
    public class WorkSpaceTasks
    {
        public List<WorkSpaceTask> Tasks { get; set; }
    }

    public class WorkSpaceTask
    {
        public string Title { get; set; }

    }
}
