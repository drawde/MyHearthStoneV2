using MyHearthStoneV2.Game.CardLibrary.Equip;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.Parameter.Biology;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.Parameter.Hero
{
    internal class HeroActionParameter: BiologyActionParameter
    {
        internal new BaseHero Biology { get; set; }
    }
}
