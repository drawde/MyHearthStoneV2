using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Controler;
namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.HeroPower
{
    public class DruidAbility : BaseHeroAbility
    {
        public override string PowerImage { get; } = "Druid.png";
        public override void CastAbility(GameContext gameContext, Card triggerCard, Card sourceCard, int targetCardIndex, int location = -1)
        {
            var uc = gameContext.GetActivationUserContext();
            var hero = gameContext.DeskCards.GetHeroByIsFirst(uc.IsFirst);
            hero.Ammo += 1;
            hero.Damage += 1;
            hero.RemainAttackTimes = hero.RemainAttackTimes == 0 ? 1 : hero.RemainAttackTimes;
            uc.RemainingHeroPowerCastCount -= 1;
        }
    }
}
