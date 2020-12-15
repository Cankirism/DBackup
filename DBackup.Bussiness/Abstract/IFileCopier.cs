namespace DBackup.Bussiness.Abstract
{
    public  interface IFileCopier
    {
        string CopyFile();
        string CopyLogFile();
    }
}