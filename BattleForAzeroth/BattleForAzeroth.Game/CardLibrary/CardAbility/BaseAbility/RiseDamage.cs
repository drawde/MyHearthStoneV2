using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.Parameter;
using System.Linq;
using BattleForAzeroth.Game.Widget.Number;
using System;
using BattleForAzeroth.Game.Event;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;
using BattleForAzeroth.Game.Widget.Condition.DamageType;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility
{
    /// <summary>
    /// 对一个目标造成伤害
    /// </summary>
    /// <typeparam name="TAG">目标</typeparam>
    /// <typeparam name="DMG">伤害量</typeparam>
    /// <typeparam name="QAT">伤害次数</typeparam>
    /// <typeparam name="DT">伤害类型</typeparam>
    public class RiseDamage<TAG, DMG, QAT, DT> : ICardAbility where TAG : IParameterFilter where DMG : INumber where QAT : INumber where DT : IDamageType
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            TAG tag = Activator.CreateInstance<TAG>();
            DT damageType = GameActivator<DT>.CreateInstance();
            DMG dmg = GameActivator<DMG>.CreateInstance();
            QAT qat = GameActivator<QAT>.CreateInstance();

            for (int i = 0; i < qat.GetNumber(actionParameter); i++)
            {
                foreach (BaseBiology biology in actionParameter.GameContext.DeskCards.Where(tag.Filter(actionParameter)).OrderBy(c => c.CastIndex))
                {
                    var para = new ActionParameter
                    {
                        PrimaryCard = biology,
                        GameContext = actionParameter.GameContext,
                        DamageOrHeal = dmg.GetNumber(actionParameter),
                        SecondaryCard = actionParameter.PrimaryCard
                    };
                    CardActionFactory.CreateAction(biology, damageType.ActionType).Action(para);
                }
            }
            return null;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
