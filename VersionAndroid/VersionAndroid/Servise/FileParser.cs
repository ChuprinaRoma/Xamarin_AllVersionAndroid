using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Unity.Attributes;

namespace VersionAndroid.Servise
{
    public class FileParser : IParser<string>
    {
        [InjectionConstructor]
        public FileParser() { }

        //Returns any data (xml, json, html,.....), for further parsing
        public string GetSource()
        {
            string sourse = null;
            try
            {
                var assets = Android.App.Application.Context.Assets;
                using (StreamReader sr = new StreamReader(assets.Open("Android.json")))
                {
                    sourse = sr.ReadToEnd();
                }
            }
            catch(Exception) { }
            return sourse;
        }

        //Pars received data
        public List<Models.Android> Parser()
        {
            string sourse      = GetSource();
            JObject jObjSourse = JObject.Parse(sourse);
            JArray jArrSourse  = (JArray)jObjSourse["Android"];
            return jArrSourse.ToObject<List<Models.Android>>();
        }
    }
}
