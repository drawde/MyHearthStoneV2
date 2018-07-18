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
    public class ChangeDamageAndLife<TAG, DMG_NUM, LFE_NUM, D, F, BUFF> : IBuff<ICardLocationFilter, IEvent, IBuffRestore<ICardLocationFilter, IEvent>> where TAG : IParameterFilter where DMG_NUM : INumber where LFE_NUM : INumber where D : IDirection
        where F : ICardLocationFilter where BUFF : IBuffRestore<ICardLocationFilter, IEvent>
    {
        public Card MasterCard { get; set; }
        public ChangeDamageAndLife(Card masterCard) => MasterCard = masterCard;
        public IBuffRestore<ICardLocationFilter, IEvent> BuffRestore { get; set; }

        public IActionOutputParameter Action(ActionParameter actionParameter)
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
