using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class BranchModel
    {
        public string Name { get; set; }
        public string NameWithHead { get; set; }
        private bool _isHead;

        public bool IsHead
        {
            get { return _isHead; }
            set
            {
                _isHead = value;
                if (_isHead == true)
                {
                    this.NameWithHead = this.Name + "   "  + "[Head]";
                }
                else
                {
                    this.NameWithHead = this.Name +  "";
                }
            }
        }


    }
}
