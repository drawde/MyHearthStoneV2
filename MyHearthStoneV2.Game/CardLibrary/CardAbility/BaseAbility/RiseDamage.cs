using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using System.Linq;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
using System;
using MyHearthStoneV2.Game.Event;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    /// <summary>
    /// 对一个目标造成伤害
    /// </summary>
    /// <typeparam name="TAG">目标</typeparam>
    /// <typeparam name="DMG">伤害量</typeparam>
    /// <typeparam name="QAT">伤害次数</typeparam>
    /// <typeparam name="DT">伤害类型</typeparam>
    public class RiseDamage<TAG, DMG, QAT, DT> : ICardAbility where TAG : IFilter where DMG : INumber where QAT : INumber where DT : IDamageType
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            TAG tag = Activator.CreateInstance<TAG>();
            DT damageType = GameActivator<DT>.CreateInstance();
            DMG dmg = GameActivator<DMG>.CreateInstance();
            QAT qat = GameActivator<QAT>.CreateInstance();

            for (int i = 0; i < qat.GetNumber(actionParameter); i++)
            {
                foreach (BaseBiology biology in actionParameter.GameContext.DeskCards.Where(tag.Filter(actionParameter)).OrderBy(c => c.CastIndex))
                {
                    var para = CardActionFactory.CreateParameter(biology, actionParameter.GameContext, dmg.GetNumber(actionParameter), secondaryCard: actionParameter.MainCard);
                    CardActionFactory.CreateAction(biology, damageType.ActionType).Action(para);
                }
            }
            return null;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
