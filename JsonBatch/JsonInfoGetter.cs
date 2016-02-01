using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codeplex.Data;

namespace JsonBatch
{
    class JsonInfoGetter
    {
        public static void getFirstFrameXY(string jsonContent, out int x, out int y)
        {
            var json = DynamicJson.Parse(jsonContent);
            var node = json["mc"];
            dynamic firstNode = null;
            foreach (KeyValuePair<string, dynamic> item in node)
            {
                //Console.WriteLine(item.Key + ":" + item.Value);
                firstNode = item.Value;
                break;
            }

            var frames = firstNode["frames"];
            var frame = frames[0];
            x = (int)frame["x"];
            y = (int)frame["y"];
            //foreach (dynamic item in frames) {
            //    return item["x"];
            //}
            //Logger.debug("failed when getFirstFrameX.");
            //return 0;
        }

        public static string modifyJson(int dltX, int dltY, string text)
        {
            var json = DynamicJson.Parse(text);
            var node = json["mc"];
            dynamic firstNode = null;
            foreach (KeyValuePair<string, dynamic> item in node)
            {
                //Console.WriteLine(item.Key + ":" + item.Value);
                firstNode = item.Value;
                break;
            }

            var frames = firstNode["frames"];
            foreach (dynamic frame in frames) {
                frame["x"] -= dltX;
                frame["y"] -= dltY;
            }

            var jsonstring = json.ToString();
            return jsonstring;
        }
    }
}
