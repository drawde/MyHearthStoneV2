using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.CardAbility;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility
{
    /// <summary>
    /// 卡牌技能基类
    /// </summary>
    public abstract class BaseCardAbility : Action.IGameAction
    {
        public virtual PriorityOfSettlement PriorityOfSettlement => PriorityOfSettlement.无;
        public virtual CastStyle CastStyle { get; set; } = CastStyle.无;
        public virtual CastCrosshairStyle CastCrosshairStyle { get; set; } = CastCrosshairStyle.无;

        public virtual List<SpellCardAbilityTime> SpellCardAbilityTimes { get; set; } = new List<SpellCardAbilityTime>();

        public virtual AbilityType AbilityType { get; set; } = AbilityType.无;


        public virtual IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            return null;
        }

        /// <summary>
        /// 触发卡牌技能
        /// </summary>
        /// <returns></returns>
        //internal abstract void CastAbility(CardActionParameter actionParameter);        
    }
}
