using MyHearthStoneV2.Game.Parameter;
using System;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Servant
{
    public class MainCardBothSidesFilter : IServantFilter
    {
        public Func<Card, bool> Filter(BaseActionParameter actionParameter)
        {
            BaseBiology baseBiology = (BaseBiology)actionParameter.MainCard;
            string leftCardCode = "", rightCardCode = "";
            int left = baseBiology.DeskIndex - 1;
            int right = baseBiology.DeskIndex + 1;
            if ((baseBiology.DeskIndex > 1 && baseBiology.DeskIndex < 8) || (baseBiology.DeskIndex > 9 && baseBiology.DeskIndex < 16) && actionParameter.GameContext.DeskCards[left] != null)
            {                
                leftCardCode = actionParameter.GameContext.DeskCards[left].CardInGameCode;
            }
            if ((baseBiology.DeskIndex > 0 && baseBiology.DeskIndex < 7) || (baseBiology.DeskIndex > 8 && baseBiology.DeskIndex < 15) && actionParameter.GameContext.DeskCards[right] != null)
            {
                rightCardCode = actionParameter.GameContext.DeskCards[right].CardInGameCode;
            }


            return new Func<Card, bool>(c => c != null && c.CardType == CardType.随从 && (c.CardInGameCode == leftCardCode || c.CardInGameCode == rightCardCode));
        }
    }
}
