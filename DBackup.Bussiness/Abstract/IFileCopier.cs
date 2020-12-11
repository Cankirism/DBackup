using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBackup.Bussiness.Abstract
{
   public  interface IFileCopier
    {

        string CopyFile();
        string CopyLogFile();

    }
}
