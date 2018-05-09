using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using System.Linq;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Direction;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using System;
using MyHearthStoneV2.Game.Action;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BUFF.ChangeBody
{
    public class ChangeDamage<TAG, NUM, QAT, D, F, BUFF> : IBuff<ICardLocationFilter, IEvent, IBuffRestore<ICardLocationFilter, IEvent>> where TAG : IFilter where NUM : INumber where QAT : INumber where D : IDirection
        where F : ICardLocationFilter where BUFF : IBuffRestore<ICardLocationFilter, IEvent>
    {
        public Card MasterCard { get; set; }
        public ChangeDamage(Card masterCard) => MasterCard = masterCard;
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
                    biology.Damage += direction.SetNumber(num);
                    biology.Buffs.AddLast(buff);

                    BaseActionParameter para = CardActionFactory.CreateParameter(biology, actionParameter.GameContext);
                    CardActionFactory.CreateAction(biology, ActionType.重置攻击次数).Action(para);
                }
            }
            return null;
        }

        //public IActionOutputParameter Restore(BaseActionParameter actionParameter)
        //{
        //    BUFF buff = Activator.CreateInstance<BUFF>();
        //    return buff.Action(actionParameter);            
        //}

        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
