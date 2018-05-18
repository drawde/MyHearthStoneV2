using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using System;
using MyHearthStoneV2.Game.CardLibrary;
namespace MyHearthStoneV2.Game.Widget.Filter.ParameterFilter
{
    public class MyBiologyFilter : IParameterFilter
    {
        public bool NoCache { get; set; } = true;
        public Func<Card, bool> Filter(BaseActionParameter actionParameter)
        {
            UserContext user = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.PrimaryCard);
            return new Func<Card, bool>(c => c != null && (c.CardType == CardType.英雄 || c.CardType == CardType.随从) && c.IsFirstPlayerCard == user.IsFirst);
        }
    }
}
