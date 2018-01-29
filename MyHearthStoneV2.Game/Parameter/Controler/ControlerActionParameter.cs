using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.Parameter.Controler
{
    internal class ControlerActionParameter : BaseActionParameter
    {
        internal bool IsActivation { get; set; }

        internal UserContext UserContext { get; set; }
    }
}
