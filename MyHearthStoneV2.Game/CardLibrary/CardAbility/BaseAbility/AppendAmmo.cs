using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.Hero;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    public class AppendAmmo : BaseCardAbility
    {
        public int AppendCount { get; set; } = 1;
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            var uc = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.MainCard);
            BaseHero hero = actionParameter.GameContext.DeskCards.GetHeroByIsFirst(uc.IsFirst);
            hero.Ammo += AppendCount;
            return null;
        }
    }
}
