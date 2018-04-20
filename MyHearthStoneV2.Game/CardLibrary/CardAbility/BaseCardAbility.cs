using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Capture;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.AbilityAttribute.AbilityTypeAttr;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.AbilityAttribute.CastTargets;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.AbilityAttribute.CastTimes;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.AbilityAttribute.CrosshairStyle;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.AbilityAttribute.SettlementPriority;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Parameter;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility
{
    /// <summary>
    /// 卡牌技能基类
    /// </summary>
    public interface IBaseCardAbility : IGameAction, ICrosshairStyle, IAbilityType, ICastTimes, ICastTargets, ISettlementPriority//, ICapture<NullFilter, NullEvent>
    {
        
        
        //CastCrosshairStyle CastCrosshairStyle { get; set; }
        
        

        //public virtual PriorityOfSettlement PriorityOfSettlement => PriorityOfSettlement.无;
        //public virtual CastStyle CastStyle { get; set; } = CastStyle.无;
        //public virtual CastCrosshairStyle CastCrosshairStyle { get; set; } = CastCrosshairStyle.无;

        //public virtual List<SpellCardAbilityTime> SpellCardAbilityTimes { get; set; } = new List<SpellCardAbilityTime>();

        //public virtual AbilityType AbilityType { get; set; } = AbilityType.无;

        //public virtual IActionOutputParameter Action(BaseActionParameter actionParameter)
        //{
        //    return null;
        //}

        //public bool TryCapture(Card card, IEvent @event)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
