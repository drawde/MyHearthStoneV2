using MyHearthStoneV2.Game.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Target
{
    internal class AllServantFilter : ITarget
    {
        public Func<BaseBiology, bool> Filter(BaseActionParameter actionParameter)
        {
            return new Func<BaseBiology, bool>(c => c != null && c.CardType == CardType.随从);
        }
    }
}
