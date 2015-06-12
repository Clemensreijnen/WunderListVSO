using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wul.Entities
{
    public class ListModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public List<TaskModel> Tasks { get; set; }
    }
}
