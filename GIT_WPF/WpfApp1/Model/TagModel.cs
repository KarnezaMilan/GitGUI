using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class TagModel
    {
        public string Name { get; set; }
        public CommitModel TargetCommit { get; set; }
        public string Sha { get; set; }

    }
}
