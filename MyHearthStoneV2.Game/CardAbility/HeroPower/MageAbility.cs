using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.CardLibrary.Controler;
namespace MyHearthStoneV2.CardLibrary.CardAbility.HeroPower
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
