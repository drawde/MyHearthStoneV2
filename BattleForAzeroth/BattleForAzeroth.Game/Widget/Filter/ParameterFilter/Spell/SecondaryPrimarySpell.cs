using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Parameter;
using System;

namespace BattleForAzeroth.Game.Widget.Filter.ParameterFilter.Spell
{
    public class SecondaryPrimarySpell : IParameterFilter
    {
        public bool NoCache { get; set; } = true;
        public Func<Card, bool> Filter(ActionParameter actionParameter)
        {
            UserContext user = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.SecondaryCard);
            return new Func<Card, bool>(c => c != null && c.CardType == CardType.法术 && c.IsFirstPlayerCard == user.IsFirst && c.CardLocation == CardLocation.手牌);
        }
    }
}
