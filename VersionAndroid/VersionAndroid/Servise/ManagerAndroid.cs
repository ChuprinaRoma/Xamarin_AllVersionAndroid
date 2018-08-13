using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Unity;
using Unity.Attributes;
using VersionAndroid.DAO;

namespace VersionAndroid.Servise
{
    public class ManagerAndroid
    {
        public ObservableCollection<VersionAndroid.Models.Android> androids = null;
        private IParser<string> parser = null;
        private ICRUD<object> _dAOsql = null;

        [InjectionConstructor]
        public ManagerAndroid(string nameOC = null)
        {
            IUnityContainer unityContainer = new UnityContainer()
                .RegisterType<IParser<string>, FileParser>();
            parser   = unityContainer.Resolve<FileParser>();
            _dAOsql  = new DAOsqlLiteRepository(nameOC);
            androids = new ObservableCollection<Models.Android>(_dAOsql.Read());
        }

        public void Work()
        {
            
            if (parser == null)
                throw new Exception();

            List<Models.Android> droids = parser.Parser();
            UpdateVersionDbAndCollection(droids);
        }
        

        private void UpdateVersionDbAndCollection(List<Models.Android> droids)
        {
            if (droids == null)
                throw new Exception();

            foreach(var droid in droids)
            {
                if(androids.FirstOrDefault(a => a.Id == droid.Id) == null)
                {
                    androids.Add(droid);
                    _dAOsql.Create(droid);
                }
            }
            
        }
    }
}
