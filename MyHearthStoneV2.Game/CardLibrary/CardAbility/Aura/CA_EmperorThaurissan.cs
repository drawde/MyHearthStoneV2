using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Aura
{
    public class CA_EmperorThaurissan : BaseCardAbility
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.光环;
        public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get; set; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.己方回合结束 };
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            UserContext player = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.MainCard);
            foreach (var card in player.HandCards)
            {
                card.Cost -= 1;
                card.BuffCost -= 1;
            }            
            return null;
        }
    }
}
