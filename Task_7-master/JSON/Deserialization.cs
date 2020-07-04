using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;

namespace JSON
{
    public class Deserialization
    {
        public List<Candle> Deserialize(string json)
        {
            List<Candle> result = new List<Candle>();

            var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            var t = ((JArray)data["t"]).ToObject<List<long>>();
            var o = ((JArray)data["o"]).ToObject<List<decimal>>();
            var c = ((JArray)data["o"]).ToObject<List<decimal>>();
            var h = ((JArray)data["o"]).ToObject<List<decimal>>();
            var l = ((JArray)data["o"]).ToObject<List<decimal>>();

            for (int i = 0; i < t.Count; i++)
            {
                var tValue = t[i];
                var oValue = o[i];
                var cValue = o[i];
                var hValue = o[i];
                var lValue = o[i];

                result.Add(new Candle(tValue, hValue, lValue, oValue, cValue));
            }

            return result;
        }
    }
}