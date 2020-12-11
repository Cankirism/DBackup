using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBackup.Bussiness;
using DBackup.Bussiness.Abstract;
using DBackup.Bussiness.Concrete;
using DBackup.Service.Concrete;
using DBackup.Service.Contract;

namespace DBackup
{
    class Program
    {
        static void Main(string[] args)
        {

            IFileCopier fileCopier = new FileCopyManager();            
            var dataFileCopyResult = fileCopier.CopyFile();
            var logFileCopyResult = fileCopier.CopyLogFile();

            StringBuilder sb = new StringBuilder();
            sb.Append( logFileCopyResult);
            sb.Append( dataFileCopyResult);

            IEMailService mailService = new EmailService();
            mailService.SendReport(sb.ToString());
          

        }
    }
}
