using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class FileModel
    { 
        #region Atribute

        private string _status;
        private string _fileName;
        private string _size;

        #endregion

        #region property
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        public string Size
        {
            get { return _size; }
            set { _size = value; }
        }
        #endregion

        #region Constructor
        public FileModel()
        { 
        }
        #endregion

      
    }
}
