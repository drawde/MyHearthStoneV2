using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.AbilityAttribute;
using MyHearthStoneV2.Game.Event;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    /// <summary>
    /// 冲锋
    /// </summary>
    public class Charge : ICardAbility
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            BaseActionParameter para = CardActionFactory.CreateParameter(actionParameter.MainCard, actionParameter.GameContext);
            CardActionFactory.CreateAction(actionParameter.MainCard, ActionType.重置攻击次数).Action(para);
            //bb.ResetRemainAttackTimes(actionParameter.GameContext);
            return null;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
