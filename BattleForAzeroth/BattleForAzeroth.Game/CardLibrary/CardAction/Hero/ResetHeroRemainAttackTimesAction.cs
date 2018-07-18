using BattleForAzeroth.Game.CardLibrary.Hero;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Parameter;


namespace BattleForAzeroth.Game.CardLibrary.CardAction.Hero
{
    /// <summary>
    /// 重置英雄攻击次数
    /// </summary>
    public class ResetHeroRemainAttackTimesAction : Action.IGameAction
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            ActionParameter para = actionParameter as ActionParameter;
            BaseHero baseHero = para.PrimaryCard as BaseHero;
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
