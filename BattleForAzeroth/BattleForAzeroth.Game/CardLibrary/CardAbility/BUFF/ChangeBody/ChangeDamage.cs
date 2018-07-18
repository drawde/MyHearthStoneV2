using BattleForAzeroth.Game.Parameter;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;
using System.Linq;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Widget.Direction;
using BattleForAzeroth.Game.Event;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using System;
using BattleForAzeroth.Game.Action;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.BUFF.ChangeBody
{
    public class ChangeDamage<TAG, NUM, D, F, BUFF> : IBuff<ICardLocationFilter, IEvent, IBuffRestore<ICardLocationFilter, IEvent>> where TAG : IParameterFilter where NUM : INumber 
        where D : IDirection
        where F : ICardLocationFilter 
        where BUFF : IBuffRestore<ICardLocationFilter, IEvent>
    {
        public Card MasterCard { get; set; }
        public ChangeDamage(Card masterCard) => MasterCard = masterCard;
        public IBuffRestore<ICardLocationFilter, IEvent> BuffRestore { get; set; }

        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            TAG tag = Activator.CreateInstance<TAG>();
            NUM num = GameActivator<NUM>.CreateInstance();
            D direction = Activator.CreateInstance<D>();
            F locationFilter = GameActivator<F>.CreateInstance();
            BUFF buff = (BUFF)Activator.CreateInstance(typeof(BUFF), MasterCard);
            BuffRestore = buff;
            foreach (BaseBiology biology in actionParameter.GameContext.AllCard.Where(tag.Filter(actionParameter)).OrderBy(c => c.CastIndex))
            {
                biology.Damage += direction.SetNumber(num);
                biology.Buffs.AddLast(buff);

                ActionParameter para = new ActionParameter
                {
                    PrimaryCard = biology,
                    GameContext = actionParameter.GameContext
                };
                CardActionFactory.CreateAction(biology, ActionType.重置攻击次数).Action(para);
            }
            return null;
        }

        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
