using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class CommitModel
    {

        public string Author
        {
            get
            {
                return AuthorName + "  ( " + AuthorEmail + " )";
            }

        }


        public string AuthorEmail { set; get; }
        public string AuthorName { set; get; }
        public string Date { set; get; }
        public string Description { set; get; }
        public string Hash { set; get; }
    
    }
}
