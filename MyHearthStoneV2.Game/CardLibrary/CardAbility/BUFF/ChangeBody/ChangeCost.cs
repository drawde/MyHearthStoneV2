using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter;
using System.Linq;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Widget.Direction;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using System;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BUFF.ChangeBody
{
    public class ChangeCost<TAG, NUM, QAT, D, F, BUFF> : IBuff<ICardLocationFilter, IEvent, IBuffRestore<ICardLocationFilter, IEvent>> where TAG : IParameterFilter where NUM : INumber where QAT : INumber where D : IDirection
        where F : ICardLocationFilter where BUFF : IBuffRestore<ICardLocationFilter, IEvent>
    {
        public Card MasterCard { get; set; }
        public ChangeCost(Card masterCard) => MasterCard = masterCard;
        public IBuffRestore<ICardLocationFilter, IEvent> BuffRestore { get; set; }

        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            TAG tag = Activator.CreateInstance<TAG>();
            NUM num = GameActivator<NUM>.CreateInstance();
            QAT qat = GameActivator<QAT>.CreateInstance();
            D direction = Activator.CreateInstance<D>();
            F locationFilter = GameActivator<F>.CreateInstance();
            BUFF buff = (BUFF)Activator.CreateInstance(typeof(BUFF), MasterCard);
            BuffRestore = buff;
            for (int i = 0; i < qat.GetNumber(actionParameter); i++)
            {
                foreach (BaseBiology biology in actionParameter.GameContext.AllCard.Where(tag.Filter(actionParameter)).OrderBy(c => c.CastIndex))
                {
                    biology.Cost += direction.SetNumber(num);
                    biology.Buffs.AddLast(buff);
                }
            }
            return null;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
