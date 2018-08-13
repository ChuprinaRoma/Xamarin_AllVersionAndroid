using System;
using System.Collections.Generic;
using SQLite;
using VersionAndroid.DAO.Models;
using VersionAndroid;
using Unity;
using Newtonsoft.Json;
using System.Linq;

namespace VersionAndroid.DAO
{
    public class DAOsqlLiteRepository : ICRUD<object>
    {
        SQLiteConnection database = null;

        public DAOsqlLiteRepository(string nameOC)
        {
            try
            {
                if (nameOC == null || nameOC == "")
                    throw new Exception();

                ISQLite sQLite =  GetDbOS(nameOC);
                if (sQLite == null)
                    throw new Exception();

                string databasePath = sQLite.GetDatabasePath("VersionDroids.db3");
                database            = new SQLiteConnection(databasePath);
                database.CreateTable<AndroidTable>();

                database.Query<Models.AndroidTable>(
                  "DELETE FROM Androids");
            }
            catch (Exception)
            {

            }
            
        }

        public void Create(VersionAndroid.Models.Android android)
        {
            try
            {
                if (android == null)
                    throw new Exception();

                AndroidTable droid = AndroidToDAOAndroid(android);
                database.Insert(droid);
            }
            catch (Exception)
            { }

        }

        public void Delete(VersionAndroid.Models.Android android)
        {
            throw new NotImplementedException();
        }

        public List<VersionAndroid.Models.Android> Read()
        {
            List<AndroidTable> droids = null;
            try
            {
                droids = database.Query<Models.AndroidTable>(
                  "SELECT * FROM Androids").
                  ToList();
            }
            catch(Exception)
            { }
            return DAOAndroidToAndroid(droids);
        }

        public void Update(VersionAndroid.Models.Android android)
        {
            throw new NotImplementedException();
        }

        //List Conversion "List<AndroidTable>" in "List<VersionAndroid.Models.Android>"    
        private List<VersionAndroid.Models.Android> DAOAndroidToAndroid(List<AndroidTable> androids)
        {
            VersionAndroid.Models.Android droid = null;
            List<VersionAndroid.Models.Android> droids = null;
            try
            {
                if (androids == null)
                    throw new Exception();

                droids = new List<VersionAndroid.Models.Android>();
                foreach (var android in androids)
                {
                    droid             = new VersionAndroid.Models.Android();
                    droid.FullName    = android.FullName;
                    droid.Id          = android.Id;
                    droid.Name        = android.Name;
                    droid.ReleaseDate = android.ReleaseDate;
                    droid.Version     = android.Version;
                    droid.WhatsNew    = JsonConvert.DeserializeObject<string[]>(android.WhatsNew);
                    droids.Add(droid);
                }
            }
            catch (Exception) { }
            return droids;
        }

        //Object Conversion "VersionAndroid.Models.Android" in "AndroidTable"  
        private Models.AndroidTable AndroidToDAOAndroid(VersionAndroid.Models.Android android)
        {
            AndroidTable droid = null;
            try
            {
                droid             = new AndroidTable();
                droid.FullName    = android.FullName;
                droid.Id          = android.Id;
                droid.Name        = android.Name;
                droid.ReleaseDate = android.ReleaseDate;
                droid.Version     = android.Version;
                droid.WhatsNew    = JsonConvert.SerializeObject(android.WhatsNew);
            }
            catch(Exception) { }
            return droid;
        }

        private ISQLite GetDbOS(string nameOC)
        {
            IUnityContainer unityContainer = new UnityContainer();
            ISQLite sQLite = null;
            try
            {
                switch (nameOC)
                {
                    case "Android": sQLite = unityContainer
                            .RegisterType<ISQLite, ConnectDbAndroid>()
                            .Resolve<ConnectDbAndroid>(); break;
                }
            }
            catch(Exception) { }

            return sQLite;
        }
    }
}
