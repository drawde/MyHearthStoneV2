using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Controler;
namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.HeroPower
{
    public class MageAbility : BaseHeroAbility
    {
        public override string PowerImage { get; } = "Mage.png";
        public override CastCrosshairStyle CastCrosshairStyle { get; } = CastCrosshairStyle.单个;
        public override void CastAbility(GameContext gameContext, Card triggerCard, Card sourceCard, int targetCardIndex, int location = -1)
        {
            var uc = gameContext.GetActivationUserContext();
            var card = gameContext.GetCardByLocation(targetCardIndex) as BaseBiology;
            gameContext.BiologyByDamege(sourceCard, 1, targetCardIndex);
            uc.RemainingHeroPowerCastCount -= 1;
        }
    }
}
