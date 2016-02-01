using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonBatch
{
    class Program
    {
        static void Main(string[] args)
        {
            if (0 == args.Length) {
                Logger.debug("输入参数(原始json)(修改后的json)(待覆盖输出的json)");
                return;
            }
            
            string originJson = args[0];
            string modifyedJson = args[1];
            string outputJson = args[2];

            /*
            string originJson = @"E:\_git\newlegend\resource\assets\image\demo\role1\r1_2r.json";
            string modifyedJson = @"E:\_git\newlegend\resource\assets\image\demo\role1\r1_3a.json";
            string outputJson = @"E:\_git\r1_4s.json";
            */

            string text = System.IO.File.ReadAllText(originJson);
            int originX = 0, originY = 0;
            JsonInfoGetter.getFirstFrameXY(text, out originX, out originY);

            string text2 = System.IO.File.ReadAllText(modifyedJson);
            int modifyX, modifyY;
            JsonInfoGetter.getFirstFrameXY(text2, out modifyX,  out modifyY);

            int dltX = originX - modifyX;
            int dltY = originY - modifyY;

            string text3 = System.IO.File.ReadAllText(outputJson);
            string resultJson = JsonInfoGetter.modifyJson(dltX, dltY, text3);
            System.IO.File.WriteAllText(outputJson, resultJson);
            return;

        }
    }
}
