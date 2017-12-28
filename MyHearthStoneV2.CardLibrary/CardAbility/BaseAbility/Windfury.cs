
using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.CardAbility.BaseAbility
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
