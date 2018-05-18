using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter;
using System.Linq;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Widget.Direction;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using System;
using MyHearthStoneV2.Game.Action;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BUFF.ChangeBody
{
    public class ChangeDamageAndLife<TAG, DMG_NUM, LFE_NUM, D, F, BUFF> : IBuff<ICardLocationFilter, IEvent, IBuffRestore<ICardLocationFilter, IEvent>> where TAG : IParameterFilter where DMG_NUM : INumber where LFE_NUM : INumber where D : IDirection
        where F : ICardLocationFilter where BUFF : IBuffRestore<ICardLocationFilter, IEvent>
    {
        public Card MasterCard { get; set; }
        public ChangeDamageAndLife(Card masterCard) => MasterCard = masterCard;
        public IBuffRestore<ICardLocationFilter, IEvent> BuffRestore { get; set; }

        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            TAG tag = Activator.CreateInstance<TAG>();
            DMG_NUM num = GameActivator<DMG_NUM>.CreateInstance();
            LFE_NUM qat = GameActivator<LFE_NUM>.CreateInstance();
            D direction = Activator.CreateInstance<D>();
            F locationFilter = GameActivator<F>.CreateInstance();
            BUFF buff = (BUFF)Activator.CreateInstance(typeof(BUFF), MasterCard);
            BuffRestore = buff;
            foreach (BaseBiology biology in actionParameter.GameContext.AllCard.Where(tag.Filter(actionParameter)).Where(c=> locationFilter.Filter(c)).OrderBy(c => c.CastIndex))
            {
                biology.BuffLife += direction.SetNumber(qat);
                biology.Life += direction.SetNumber(qat);
                biology.Damage += direction.SetNumber(num);
                biology.Buffs.AddLast(buff);

                BaseActionParameter para = CardActionFactory.CreateParameter(biology, actionParameter.GameContext);
                CardActionFactory.CreateAction(biology, ActionType.重置攻击次数).Action(para);
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
