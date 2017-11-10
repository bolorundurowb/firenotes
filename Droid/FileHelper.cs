using System;
using System.IO;
using Xamarin.Forms;
using firenotes.Droid;
using firenotes.Interfaces;

[assembly: Dependency(typeof(FileHelper))]
namespace firenotes.Droid
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
