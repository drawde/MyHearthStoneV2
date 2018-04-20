using MyHearthStoneV2.Game.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.Parameter.Player
{
    public class DrawCardActionParameter: BaseActionParameter
    {
        public int DrawCount { get; set; }
        public UserContext UserContext { get; set; }
    }
}
