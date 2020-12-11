using DBackup.Bussiness.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DBackup.Bussiness.Model;

namespace DBackup.Bussiness.Concrete
{
    public class FileCopyManager : IFileCopier
    {

        SourceFile _sourceFile;
        TargetFile _targetFile;
        string message;
        public FileCopyManager()
        {
            _sourceFile = FileCreator.SetSourceFile();
            _targetFile = FileCreator.CreateTargetFile(_sourceFile.DataSourceFile);
            message = string.Empty;
        }
        public string CopyFile()
        {
            try
            {
                File.Copy(_sourceFile.DataSourceFile, _targetFile.TargetDataFile);
                message = $"DB kopyalama başarıyla tamamlandı. Tamamlanma Zamanı  \t: {DateTime.Now.ToShortTimeString()}";
            }
            catch (Exception ex)
            {
                message = $"DB kopyalama işleminde hata : {ex.Message}";
            }

            return message;
        }
        public string CopyLogFile()
        {
            try
            {
                File.Copy(_sourceFile.LogSourceFile, _targetFile.TargetLogFile);
                message = $"DB LOG kopyalama başarıyla tamamlandı. Tamamlanma Zamanı  \t: {DateTime.Now.ToShortTimeString()}";
            }
            catch (Exception ex)
            {
                message = $"Log kopyalam işleminde Hata : {ex.Message}";
            }

            return message;
        }
    }
}
