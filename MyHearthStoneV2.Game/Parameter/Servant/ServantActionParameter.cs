using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Parameter.Biology;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.Parameter.Servant
{
    internal class ServantActionParameter : BiologyActionParameter
    {
        internal new BaseServant Biology { get; set; }
    }
}
