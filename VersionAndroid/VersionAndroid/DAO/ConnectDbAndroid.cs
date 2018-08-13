using System;
using System.IO;
using VersionAndroid.DAO;
using Xamarin.Forms;

[assembly: Dependency(typeof(ConnectDbAndroid))]
namespace VersionAndroid.DAO
{
    public class ConnectDbAndroid : ISQLite
    {
        //Returns the path for the database
        public string GetDatabasePath(string filename)
        {
            string path = null;
            try
            {
                if (filename == null || filename == "")
                    throw new Exception();

                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                path                 = Path.Combine(documentsPath, filename);
                
            }
            catch(Exception)
            { }
            return path;
        }
    }
}
