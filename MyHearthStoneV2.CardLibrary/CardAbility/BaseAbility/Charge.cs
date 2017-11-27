using System.Collections.Generic;
using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.Context;
using MyHearthStoneV2.CardEnum;

namespace MyHearthStoneV2.CardLibrary.CardAbility.BaseAbility
{
    /// <summary>
    /// 冲锋
    /// </summary>
    public class Charge : BaseSpecialEffect
    {
        public override BuffTimeLimit buffTime { get; } = BuffTimeLimit.己方回合结束;
        public override List<SpellCardAbilityTime> LstSpellCardAbilityTime { get; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.入场 };
        public override void CastAbility(GameContext gameContext, Card triggerCard, Card sourceCard, List<int> targetCardIndex, int location)
        {
            BaseBiology bb = sourceCard as BaseBiology;
            bb.RemainAttackTimes += 1;
        }
    }
}
