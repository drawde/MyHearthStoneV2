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
        public virtual BaseBiology Biology { get; set; }

        public int DamageOrHeal { get; set; }

        public int DeskIndex { get; set; }
    }
}
