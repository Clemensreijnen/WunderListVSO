using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wul.Entities;

namespace Wul.Business
{
    public class Workspace
    {
        private static Workspace _current;

        public static Workspace Current
        {
            get { return _current ?? (_current = new Workspace()); }
        }

        public Workspace()
        {
            Lists = new List<ListModel>();
        }

        public List<ListModel> Lists { get; set; }
    }
}
