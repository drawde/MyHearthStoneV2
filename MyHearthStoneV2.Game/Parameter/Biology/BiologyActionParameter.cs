using MyHearthStoneV2.Game.CardLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.Parameter.Biology
{
    public class BiologyActionParameter: BaseActionParameter
    {
        internal virtual BaseBiology Biology { get; set; }

        internal int DamageOrHeal { get; set; }

        internal int DeskIndex { get; set; }
    }
}
