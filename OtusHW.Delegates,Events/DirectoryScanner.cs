using System;
using System.IO;

namespace OtusHW.Delegates_Events
{
    public class FileFoundEventArgs : EventArgs //класс аргументов, т.е. того что будет передовать Event
                                                //в Delegate (метод бработчик в делегате)
                                                //только почему теперь каждый раз создаётся экземпляр класса? или нет?
    {
        public string FileName { get; }

        public FileFoundEventArgs(string fileName)
        {
            FileName = fileName;
        }
    }

    public class DirectoryScanner
    {
        public event EventHandler<FileFoundEventArgs> FileFound;

        public void ScanDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                foreach (var fileName in Directory.GetFiles(path))
                {
                    OnFileFound(fileName);
                }
            }
            else
            {
                throw new DirectoryNotFoundException($"The directory '{path}' does not exist.");
            }
        }

        protected virtual void OnFileFound(string fileName)
        {
            FileFound?.Invoke(this, new FileFoundEventArgs(fileName));
        }
    }

}
