
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
    /// 圣盾
    /// </summary>
    public class HolyShield : BaseCardAbility
    {
        public override List<SpellCardAbilityTime> LstSpellCardAbilityTime { get; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.己方随从受到伤害, SpellCardAbilityTime.己方随从受到攻击 };
        public override void CastAbility(GameContext gameContext, Card triggerCard, Card sourceCard, List<int> targetCardIndex, int location)
        {
            //BaseBiology bb = sourceCard as BaseBiology;
            sourceCard.Abilities.RemoveAt(sourceCard.Abilities.FindIndex(c => c == this));
        }
    }
}
