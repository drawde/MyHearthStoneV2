using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Context;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.HeroPower
{
    public class WarriorAbility : BaseHeroAbility
    {
        public override string PowerImage { get; } = "Druid.png";
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            var uc = actionParameter.GameContext.GetActivationUserContext();
            var hero = actionParameter.GameContext.DeskCards.GetHeroByIsFirst(uc.IsFirst);
            hero.Ammo += 2;
            return null;
        }
    }
}
