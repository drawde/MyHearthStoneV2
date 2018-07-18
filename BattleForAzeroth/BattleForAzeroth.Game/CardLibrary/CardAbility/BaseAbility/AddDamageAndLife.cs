using BattleForAzeroth.Game.Parameter;
using System.Linq;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Widget.Direction;
using BattleForAzeroth.Game.Event;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using System;
using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility
{
    public class AddDamageAndLife<TAG, NUM, QAT, D, F> : ICardAbility where TAG : IParameterFilter where NUM : INumber where QAT : INumber where D : IDirection
        where F : ICardLocationFilter
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            TAG tag = Activator.CreateInstance<TAG>();
            NUM num = GameActivator<NUM>.CreateInstance();
            QAT qat = GameActivator<QAT>.CreateInstance();
            D direction = Activator.CreateInstance<D>();
            F locationFilter = GameActivator<F>.CreateInstance();

            for (int i = 0; i < qat.GetNumber(actionParameter); i++)
            {
                foreach (BaseBiology biology in actionParameter.GameContext.AllCard.Where(tag.Filter(actionParameter)).OrderBy(c => c.CastIndex))
                {
                    biology.BuffLife += direction.SetNumber(num);
                    biology.Life += direction.SetNumber(num);
                    biology.Damage += direction.SetNumber(num);


                    ActionParameter para = new ActionParameter
                    {
                        PrimaryCard = biology,
                        GameContext = actionParameter.GameContext
                    };
                    CardActionFactory.CreateAction(biology, ActionType.重置攻击次数).Action(para);
                }
            }
            return null;
        }

        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
