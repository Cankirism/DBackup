using System;
using System.IO;
using DBackup.Bussiness.Model;

namespace DBackup.Bussiness.Concrete
{
    public class FileCreator
    {
        // Data log file extension 
        static string dataFileExt = System.Configuration.ConfigurationManager.AppSettings["DataFileExt"];

        // Log File Extension 
        static string logFileExt = System.Configuration.ConfigurationManager.AppSettings["LogFileExt"];

        public static SourceFile SetSourceFile()
        {
            // Log file datetime settings
            var year = DateTime.Now.Year.ToString();
            var month = DateTime.Now.Month < 10 ? $"0{DateTime.Now.Month}" : DateTime.Now.Month.ToString();
            var day = DateTime.Now.Day < 10 ? $"0{DateTime.Now.Day}" : DateTime.Now.Day.ToString();
            var hour = System.Configuration.ConfigurationManager.AppSettings["HourFormat"];

            // Log file prefix
            var prefix = System.Configuration.ConfigurationManager.AppSettings["Prefix"];

            // Source file drive
            var sourceDrive = System.Configuration.ConfigurationManager.AppSettings["SourceDrive"];

            var sourceFile = $"{prefix}-{year}-{month}-{day}-{hour}";

            SourceFile file = new SourceFile
            {
                DataSourceFile = Path.Combine(sourceDrive, $"{sourceFile}.{dataFileExt}"),
                LogSourceFile = Path.Combine(sourceDrive, $"{sourceFile}.{logFileExt}")
            };

            return file;
        }

        public static TargetFile CreateTargetFile(string sourceFile)
        {
            FileInfo file = new FileInfo(sourceFile);
            Console.WriteLine($" =>>>>>>> Dosya Oluşturma Tarihi \t : {file.LastWriteTime}");

            var backupFileYear = file.LastWriteTime.Year;
            var backupFileMonth = file.LastWriteTime.Month;
            var backupFileDay = file.LastWriteTime.Day;
            var backupHour = file.LastWriteTime.Hour;

            var targetDirectory = $"{backupFileYear}-{backupFileMonth}-{backupFileDay}-{backupHour}";
            var targetDrive = System.Configuration.ConfigurationManager.AppSettings["TargetDrive"];

            var targetPath = $"{targetDrive}{targetDirectory}";

            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }
            else
            {
                Console.WriteLine($"{targetPath} dizininde zaten mevcut. Kaynak dosya değişmemiş olabilir ");
            }

            TargetFile targetFile = new TargetFile
            {
                TargetDataFile = Path.Combine(targetPath, $"{targetDirectory}.{dataFileExt}"),
                TargetLogFile = Path.Combine(targetPath, $"{targetDirectory}.{logFileExt}")
            };

            return targetFile;
        }
    }
}