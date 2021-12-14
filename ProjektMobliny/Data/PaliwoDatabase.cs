using ProjektMobliny.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjektMobliny.Data
{
    public class PaliwoDatabase
    {
        static SQLiteAsyncConnection Database;

        public PaliwoDatabase()
        {
            string DatabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Paliwo.db");
            Assembly assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            Stream embeddedDatabaseStream = assembly.GetManifestResourceStream("ProjektMobilny.Paliwo.db");

            if (!File.Exists(DatabasePath))
                {
               FileStream fileStreamToWrite = File.Create(DatabasePath);
               embeddedDatabaseStream.Seek(0, SeekOrigin.Begin);
               embeddedDatabaseStream.CopyTo(fileStreamToWrite);
               fileStreamToWrite.Close();


            }
            Database = new SQLiteAsyncConnection(DatabasePath);
            Database.CreateTableAsync<Item>().Wait();
        }
        public Task<List<Item>> GetItemsAsync()
        {
            return Database.Table<Item>().ToListAsync();
        }
    }
}
