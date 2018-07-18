using BattleForAzeroth.Game.CardLibrary.Hero;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Parameter;

namespace BattleForAzeroth.Game.CardLibrary.CardAction.Hero
{
    /// <summary>
    /// 英雄受到伤害（被火球砸、火冲点）
    /// </summary>
    public class HeroByDamegeAction : Action.IGameAction
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            ActionParameter para = actionParameter as ActionParameter;
            BaseHero baseHero = para.PrimaryCard as BaseHero;
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
                ActionParameter deductionPara = new ActionParameter()
                {
                    PrimaryCard = baseHero,
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
