using BattleForAzeroth.Game.CardLibrary.CardAction.Player;
using BattleForAzeroth.Game.Parameter;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;
using System.Linq;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Event;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility
{
    public class DrawCard<UC, D> : ICardAbility where UC : IUserContextFilter where D : INumber
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            D drawCount = GameActivator<D>.CreateInstance();
            UC uc = GameActivator<UC>.CreateInstance();
            var users = actionParameter.GameContext.Players.Where(uc.Filter(actionParameter));
            foreach (UserContext user in users)
            {
                var para = new ActionParameter()
                {
                    DrawCount = drawCount.GetNumber(actionParameter),
                    GameContext = actionParameter.GameContext,
                    UserContext = user
                };
                new DrawCardAction().Action(para);
            }
            return null;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
