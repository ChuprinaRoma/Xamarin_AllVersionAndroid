using System;
using System.Collections.Generic;
using System.Text;

namespace VersionAndroid.DAO
{
    public interface ISQLite
    {
        string GetDatabasePath(string filename);
    }
}
