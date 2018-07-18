using BattleForAzeroth.Game.Parameter;
using BattleForAzeroth.Game.CardLibrary.CardAbility.AbilityAttribute;
using BattleForAzeroth.Game.Event;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;
using System.Linq;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility
{
    public class GameOver<UC> : DefaultAttribute, ICardAbility where UC : IUserContextFilter
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            UC uc = GameActivator<UC>.CreateInstance();
            var user = actionParameter.GameContext.Players.Where(uc.Filter(actionParameter)).First();
            actionParameter.GameContext.GameStatus = user.IsFirst ? GameStatus.先手胜利 : GameStatus.后手胜利;
            return null;
        }

        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
