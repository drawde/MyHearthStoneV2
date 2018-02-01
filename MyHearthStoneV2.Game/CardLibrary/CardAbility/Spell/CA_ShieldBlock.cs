using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter.Player;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Player;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Spell
{
    public class CA_ShieldBlock : BaseCardAbility
    {

        public override AbilityType AbilityType { get; set; } = AbilityType.法术;
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            BaseHero hero = actionParameter.GameContext.DeskCards.GetHeroByIsFirst(actionParameter.GameContext.GetUserContextByMyCard(actionParameter.MainCard).IsFirst);
            hero.Ammo += 5;
            var uc = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.MainCard);
            DrawCardActionParameter para = new DrawCardActionParameter()
            {
                DrawCount = 1,
                GameContext = actionParameter.GameContext,
                UserContext = uc
            };
            new DrawCardAction().Action(para);
            return null;
        }
    }
}
