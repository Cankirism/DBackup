using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBackup.Service.Contract

{
public  interface IEMailService
    {

        void SendReport(string reportDetails);
    }
}
