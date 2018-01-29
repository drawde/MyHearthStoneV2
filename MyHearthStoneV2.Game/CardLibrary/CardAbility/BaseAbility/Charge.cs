using System.Collections.Generic;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.CardAction;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Action;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    /// <summary>
    /// 冲锋
    /// </summary>
    public class Charge : BaseCardAbility
    {
        public override AbilityType AbilityType => AbilityType.冲锋;
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            BaseActionParameter para = CardActionFactory.CreateParameter(actionParameter.MainCard, actionParameter.GameContext);
            CardActionFactory.CreateAction(actionParameter.MainCard, ActionType.重置攻击次数).Action(para);
            //bb.ResetRemainAttackTimes(actionParameter.GameContext);
            return null;
        }        
    }
}
