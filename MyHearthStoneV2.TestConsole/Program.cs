using MyHearthStoneV2.BLL;
using MyHearthStoneV2.CardAction.Servant.NAXX;
using MyHearthStoneV2.CardEnum;
using MyHearthStoneV2.CardLibrary;
using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.Servant.Classical;
using MyHearthStoneV2.CardLibrary.Servant.NAXX;
using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.GameControler;
using MyHearthStoneV2.Model;
using MyHearthStoneV2.Redis;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //ClassProxy.tc = new TestClass();
            var noclass = new NoClass() { nnn = "mmp" };
            var tc = ClassProxy.tc;
            var lll = ClassProxy.tc.lstNoClass;
            lll.Add(noclass);
            tc.lstNoClass = lll;
            ClassProxy.tc = tc;
            ClassProxy.tc.lstNoClass.RemoveAt(0);
            var ddd = ClassProxy.tc;
            Console.ReadKey();
        }
    }
}
