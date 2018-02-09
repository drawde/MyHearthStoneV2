using MyHearthStoneV2.Game.Parameter;
using System.Linq;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.Hero;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    public class UpgradeWeapon : BaseCardAbility
    {
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            UserContext user = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.MainCard);
            BaseHero hero = actionParameter.GameContext.DeskCards.GetHeroByIsFirst(user.IsFirst);
            if (hero.Equip != null)
            {
                hero.Equip.Damage += 2;
            }
            return null;
        }
    }
}
