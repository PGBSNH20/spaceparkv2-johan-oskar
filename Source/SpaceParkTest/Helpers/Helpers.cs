using Newtonsoft.Json;
using SpaceParkAPI.APIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceParkTest.Helpers
{
    public static class CloneTestData
    {
        public static List<T> CloneCollection<T>(IEnumerable<T> data)
        {
            string dataAsJson = JsonConvert.SerializeObject(data);
            return (List<T>)JsonConvert.DeserializeObject<IEnumerable<T>>(dataAsJson);
        }

        internal static T CloneObject<T>(Object data)
        {
            string dataAsJson = JsonConvert.SerializeObject(data);
            return JsonConvert.DeserializeObject<T>(dataAsJson);
        }
    }

    public static class Compare
    {
        public static bool Equivalent(object object1, object object2)
        {
            return JsonConvert.SerializeObject(object1) == JsonConvert.SerializeObject(object2);
        }
    }
}
