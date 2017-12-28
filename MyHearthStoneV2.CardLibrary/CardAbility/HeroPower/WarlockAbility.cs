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
