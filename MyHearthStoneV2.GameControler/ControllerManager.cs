using MyHearthStoneV2.GameControler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.GameControler
{
    public class ControllerManager
    {
        private static List<Controler> lstCtl = new List<Controler>();
        public static Controler CtlInstance(string gameID)
        {
            return lstCtl.First(c => c.GameID == gameID);
        }
    }
}
