using MyHearthStoneV2.Game.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.Parameter.Player
{
    internal class DrawCardActionParameter: BaseActionParameter
    {
        internal int DrawCount { get; set; }
        internal UserContext UserContext { get; set; }
    }
}
