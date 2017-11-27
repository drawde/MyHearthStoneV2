using MyHearthStoneV2.CardEnum;
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
    /// 嘲讽
    /// </summary>
    public class Taunt : BaseSpecialEffect
    {        
        public override List<SpellCardAbilityTime> LstSpellCardAbilityTime { get; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.入场 };
        public override void CastAbility(GameContext gameContext, Card triggerCard, Card sourceCard, List<int> targetCardIndex, int location)
        {
        }
    }
}
