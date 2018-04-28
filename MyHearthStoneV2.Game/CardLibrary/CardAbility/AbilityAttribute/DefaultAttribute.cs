using System.Collections.Generic;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.AbilityAttribute.AbilityTypeAttr;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.AbilityAttribute.CastTargets;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.AbilityAttribute.CastTimes;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.AbilityAttribute.CrosshairStyle;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.AbilityAttribute.SettlementPriority;
using MyHearthStoneV2.Game.Parameter;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.AbilityAttribute
{
    public class DefaultAttribute : ICrosshairStyle, IAbilityType, ICastTimes, ICastTargets, ISettlementPriority
    {
        public virtual CastCrosshairStyle CastCrosshairStyle { get; set; } = CastCrosshairStyle.无;
        public virtual AbilityType AbilityType { get; set; } = AbilityType.无;
        public virtual List<SpellCardAbilityTime> SpellCardAbilityTimes { get; set; } = new List<SpellCardAbilityTime>();
        public virtual CastStyle CastStyle { get; set; } = CastStyle.无;
        public virtual PriorityOfSettlement PriorityOfSettlement { get; set; } = PriorityOfSettlement.无;
    }
}
