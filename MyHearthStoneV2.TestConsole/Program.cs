using MyHearthStoneV2.BLL;
using MyHearthStoneV2.CardAction.Servant.NAXX;
using MyHearthStoneV2.CardEnum;
using MyHearthStoneV2.CardLibrary;
using MyHearthStoneV2.CardLibrary.Servant.Classical;
using MyHearthStoneV2.CardLibrary.Servant.NAXX;
using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.GameControler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test<string>(Action, "Hello World!");
            //Test<int>(Action, 1000);
            //Test<string>(p => { Console.WriteLine("{0}", p); }, "Hello World");//使用Lambda表达式定义委托

            //GuiLingZhiZhu zhizhu = new GuiLingZhiZhu();
            //zhizhu.Life = 3;
            //zhizhu.Life = 0;
            //Controler ctl = new Controler();
            //Al_akir ao = new Al_akir();
            //ao.CardLocation = CardLocation.场上;

            GuiLingZhiZhu zhizhu = new GuiLingZhiZhu();
            SignUtil.CreateSign("");
            new hs_invitation_BLL().CreateInvitationCode("58657C04BCADF3C6AA26F2B79D24994D");
            GuiLingZhiZhuAction action = new GuiLingZhiZhuAction(zhizhu);
            zhizhu.Damage = 0;
            Console.WriteLine(zhizhu.Damage);
            Console.WriteLine(action._entity.Damage);
            //action.Life
            Console.ReadKey();
        }
        public static void Test<T>(Action<T> action, T p)
        {
            action(p);
        }
        private static void Action(string s)
        {
            Console.WriteLine(s);
        }
        private static void Action(int s)
        {
            Console.WriteLine(s);
        }
    }
}
