using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Controler;
namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.HeroPower
{
    public class WarlockAbility : BaseHeroAbility
    {
        public override string PowerImage { get; } = "Warlock.png";
        public override void CastAbility(GameContext gameContext, Card triggerCard, Card sourceCard, int targetCardIndex, int location = -1)
        {
            var uc = gameContext.GetActivationUserContext();
            var hero = uc.Hero;
            hero.Life -= 2;
            gameContext.DrawCard();
            uc.RemainingHeroPowerCastCount -= 1;
        }
    }
}
