using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Hero;
using System.Collections.Generic;
using System.Linq;

namespace MyHearthStoneV2.Game.CardLibrary.CardAction.Hero
{
    /// <summary>
    /// 英雄受到伤害（被火球砸、火冲点）
    /// </summary>
    public class HeroByDamegeAction : Action.IGameAction
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            HeroActionParameter para = actionParameter as HeroActionParameter;
            BaseHero baseHero = para.Biology;
            GameContext gameContext = para.GameContext;
            int damege = para.DamageOrHeal;
            Card targetCard = para.SecondaryCard;

            var trueDamege = damege;
            if(baseHero.HasHolyShield == false)
            {
                if (trueDamege >= baseHero.Ammo)
                {
                    trueDamege -= baseHero.Ammo;
                    baseHero.Ammo = 0;
                }
                else
                {
                    baseHero.Ammo -= trueDamege;
                    trueDamege = 0;
                }
                DeductionHeroLifeAction deductionAct = new DeductionHeroLifeAction();
                HeroActionParameter deductionPara = new HeroActionParameter()
                {
                    Biology = baseHero,
                    GameContext = gameContext,
                    SecondaryCard = targetCard,
                    DamageOrHeal = trueDamege,
                };
                deductionAct.Action(deductionPara);
                //DeductionBiologyLife(baseHero, context, targetCard, trueDamege);
            }
            return null;
        }
    }
}
