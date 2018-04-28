using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Aura
{
    public class REV_DireWolfAlpha : ICardAbility
    {
        public PriorityOfSettlement PriorityOfSettlement { get; set; } = PriorityOfSettlement.无;
        public CastStyle CastStyle { get; set; } = CastStyle.无;
        public CastCrosshairStyle CastCrosshairStyle { get; set; } = CastCrosshairStyle.无;

        public List<SpellCardAbilityTime> SpellCardAbilityTimes { get; set; } = new List<SpellCardAbilityTime>();

        public AbilityType AbilityType { get; set; } = AbilityType.无;
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            BaseServant servant = actionParameter.MainCard as BaseServant;
            servant.Damage -= 1;
            if (servant.Damage < 1)
            {
                servant.Damage = 0;
            }
            return null;
        }
    }
}
