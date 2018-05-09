using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Hero;

namespace MyHearthStoneV2.Game.CardLibrary.CardAction.Hero
{
    /// <summary>
    /// 重置英雄攻击次数
    /// </summary>
    public class ResetHeroRemainAttackTimesAction : Action.IGameAction
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            HeroActionParameter para = actionParameter as HeroActionParameter;
            BaseHero baseHero = para.Biology;
            GameContext gameContext = para.GameContext;

            if (((baseHero.Equip != null && baseHero.Equip.Damage > 0) || baseHero.Damage > 0) && baseHero.CanAttack)
            {
                baseHero.RemainAttackTimes += 1;
                if (baseHero.Equip != null && baseHero.Equip.HasWindfury)
                {
                    baseHero.RemainAttackTimes += 1;
                }
            }

            return null;
        }
    }
}
