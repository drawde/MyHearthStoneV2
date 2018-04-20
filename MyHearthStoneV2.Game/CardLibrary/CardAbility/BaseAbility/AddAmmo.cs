using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Quantity;
namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    public class AddAmmo<Q> : IBaseCardAbility where Q : IQuantity
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
