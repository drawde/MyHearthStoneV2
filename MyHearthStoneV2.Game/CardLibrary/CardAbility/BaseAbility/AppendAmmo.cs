using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    internal class AppendAmmo<Q> : BaseCardAbility where Q : IQuantity
    {
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            var uc = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.MainCard);
            BaseHero hero = actionParameter.GameContext.DeskCards.GetHeroByIsFirst(uc.IsFirst);
            hero.Ammo += GameActivator<Q>.CreateInstance().Quantity;
            return null;
        }
    }
}
