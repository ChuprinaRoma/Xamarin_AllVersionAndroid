using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace VersionAndroid.DAO
{
    public interface ICRUD<T>
    {
        void Create(VersionAndroid.Models.Android android);

        List<VersionAndroid.Models.Android> Read();

        void Update(VersionAndroid.Models.Android android);

        void Delete(VersionAndroid.Models.Android android);
    }
}
