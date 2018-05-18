using MyHearthStoneV2.Game.Parameter;
using System.Linq;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Widget.Direction;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using System;
using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    public class AddDamageAndLife<TAG, NUM, QAT, D, F> : ICardAbility where TAG : IParameterFilter where NUM : INumber where QAT : INumber where D : IDirection
        where F : ICardLocationFilter
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
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


                    BaseActionParameter para = CardActionFactory.CreateParameter(biology, actionParameter.GameContext);
                    CardActionFactory.CreateAction(biology, ActionType.重置攻击次数).Action(para);
                }
            }
            return null;
        }

        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
