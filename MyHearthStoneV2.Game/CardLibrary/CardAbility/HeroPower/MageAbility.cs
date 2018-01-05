using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Hero;
using MyHearthStoneV2.Game.CardLibrary.Hero;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.HeroPower
{
    public class MageAbility : BaseHeroAbility
    {
        public override string PowerImage { get; } = "Mage.png";
        public override CastCrosshairStyle CastCrosshairStyle { get; } = CastCrosshairStyle.单个;
        public override void CastAbility(GameContext gameContext, Card triggerCard, Card sourceCard, int targetCardIndex, int location = -1)
        {
            var uc = gameContext.GetActivationUserContext();
            var hero = sourceCard as BaseHero;
            hero.BiologyByDamege(triggerCard, gameContext, 1);
            uc.RemainingHeroPowerCastCount -= 1;
        }
    }
}
