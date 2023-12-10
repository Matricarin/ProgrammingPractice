using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Lib
{
    public class FileChecker
    {
        private string[] _files;

        public FileChecker(string[] args)
        {
            _files = args;
            CheckFiles(_files);
        }

        private void CheckFiles(string[] files)
        {

        }
    }
}
