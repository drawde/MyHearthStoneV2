using System.Collections.Generic;
using BattleForAzeroth.Game.CardLibrary.CardAbility.AbilityAttribute.AbilityTypeAttr;
using BattleForAzeroth.Game.CardLibrary.CardAbility.AbilityAttribute.CastTargets;
using BattleForAzeroth.Game.CardLibrary.CardAbility.AbilityAttribute.CastTimes;
using BattleForAzeroth.Game.CardLibrary.CardAbility.AbilityAttribute.CrosshairStyle;
using BattleForAzeroth.Game.CardLibrary.CardAbility.AbilityAttribute.SettlementPriority;
using BattleForAzeroth.Game.Parameter;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.AbilityAttribute
{
    public class DefaultAttribute : ICrosshairStyle, IAbilityType, ICastTimes, ICastTargets, ISettlementPriority
    {
        public virtual CastCrosshairStyle CastCrosshairStyle { get; set; } = CastCrosshairStyle.无;
        public virtual AbilityType AbilityType { get; set; } = AbilityType.无;
        //public virtual List<SpellCardAbilityTime> SpellCardAbilityTimes { get; set; } = new List<SpellCardAbilityTime>();
        public virtual CastStyle CastStyle { get; set; } = CastStyle.无;
        public virtual PriorityOfSettlement PriorityOfSettlement { get; set; } = PriorityOfSettlement.无;
    }
}
