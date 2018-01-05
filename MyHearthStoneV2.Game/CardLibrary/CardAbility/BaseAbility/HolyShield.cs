using MyHearthStoneV2.Game.Context;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    /// <summary>
    /// 圣盾
    /// </summary>
    public class HolyShield : BaseCardAbility
    {
        public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.己方随从受到伤害后 };
        public override void CastAbility(GameContext gameContext, Card triggerCard, Card sourceCard, int targetCardIndex, int location)
        {
            //BaseBiology bb = sourceCard as BaseBiology;
            sourceCard.Abilities.RemoveAt(sourceCard.Abilities.FindIndex(c => c == this));
        }
    }
}
