using System;
using System.IO;
using firenotes.Interfaces;
using firenotes.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace firenotes.iOS
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}
