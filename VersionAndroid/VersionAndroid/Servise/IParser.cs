using Android.Content.Res;
using System;
using System.Collections.Generic;
using System.Text;

namespace VersionAndroid.Servise
{
    public interface IParser<T> 
    {
        T GetSource();

        List<Models.Android> Parser();
    }
}
