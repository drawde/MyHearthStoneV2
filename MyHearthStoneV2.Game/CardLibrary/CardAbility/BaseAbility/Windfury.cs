using MyHearthStoneV2.Game.Context;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    /// <summary>
    /// 风怒
    /// </summary>
    public class Windfury : BaseCardAbility
    {
        public override BuffTimeLimit BuffTime { get; } = BuffTimeLimit.己方回合结束;
        public override List<SpellCardAbilityTime> LstSpellCardAbilityTime { get; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.己方随从入场 };
        public override void CastAbility(GameContext gameContext, Card triggerCard, Card sourceCard, int targetCardIndex, int location)
        {
            BaseBiology bb = sourceCard as BaseBiology;
            bb.RemainAttackTimes += 2;
        }
    }
}
