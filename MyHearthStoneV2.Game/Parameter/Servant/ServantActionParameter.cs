using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Parameter.Biology;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.Parameter.Servant
{
    public class ServantActionParameter : BiologyActionParameter
    {
        public new BaseServant Biology { get; set; }
    }
}
