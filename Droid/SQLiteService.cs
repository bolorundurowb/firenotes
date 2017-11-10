using System;
using System.IO;
using firenotes.Interfaces;
using SQLite;

namespace firenotes.Droid
{
    public class SQLiteService : ISQLite
    {
        public SQLiteService()
        {
        }

        public SQLiteConnection GetConnection()
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(appDataPath, Constants.DbFileName);
            var platform = new SQLite.Net.
        }
    }
}
