using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.Context;
using MyHearthStoneV2.CardLibrary.Controler;
namespace MyHearthStoneV2.CardLibrary.CardAbility.HeroPower
{
    public class DruidAbility : BaseHeroAbility
    {
        public override string PowerImage { get; } = "Druid.png";
        public override void CastAbility(GameContext gameContext, Card triggerCard, Card sourceCard, int targetCardIndex, int location = -1)
        {
            var uc = gameContext.GetActivationUserContext();
            var hero = uc.Hero;
            hero.Ammo += 1;
            hero.Damage += 1;
            hero.RemainAttackTimes = hero.RemainAttackTimes == 0 ? 1 : hero.RemainAttackTimes;
            uc.RemainingHeroPowerCastCount -= 1;
        }
    }
}
