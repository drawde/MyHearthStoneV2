using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using System;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Spell
{
    public class MainHandSpell : IFilter
    {
        public bool NoCache { get; set; } = true;
        public Func<Card, bool> Filter(BaseActionParameter actionParameter)
        {
            UserContext user = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.MainCard);
            return new Func<Card, bool>(c => c != null && c.CardType == CardType.法术 && c.IsFirstPlayerCard == user.IsFirst && c.CardLocation == CardLocation.手牌);
        }
    }
}
