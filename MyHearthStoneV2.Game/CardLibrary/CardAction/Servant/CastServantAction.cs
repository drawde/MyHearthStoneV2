using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.CardAbility;
using MyHearthStoneV2.Game.Parameter.Servant;
using System.Linq;
namespace MyHearthStoneV2.Game.CardLibrary.CardAction.Servant
{
    /// <summary>
    /// 随从进场（不触发技能，比如召唤出来的随从）
    /// </summary>
    internal class CastServantAction : IGameAction
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            ServantActionParameter para = actionParameter as ServantActionParameter;
            BaseServant servant = para.Biology;
            GameContext gameContext = para.GameContext;
            BaseBiology attackCard = para.SecondaryCard as BaseBiology;
            int deskIndex = para.DeskIndex;

            var user = gameContext.GetUserContextByMyCard(servant);
            gameContext.CastCardCount++;
            servant.CastIndex = gameContext.CastCardCount;
            servant.CardLocation = CardLocation.场上;
            servant.DeskIndex = deskIndex;
            servant.CanAttack = true;
            gameContext.DeskCards[deskIndex] = servant;
            if (user.HandCards.Any(c => c.CardInGameCode == servant.CardInGameCode))
                user.HandCards.RemoveAt(user.HandCards.FindIndex(c => c.CardInGameCode == servant.CardInGameCode));
            else if (user.StockCards.Any(c => c.CardInGameCode == servant.CardInGameCode))
                user.StockCards.RemoveAt(user.HandCards.FindIndex(c => c.CardInGameCode == servant.CardInGameCode));
            if (servant.Abilities.Any(c => c.AbilityType == AbilityType.冲锋))
            {
                servant.Abilities.First(c => c.AbilityType == AbilityType.冲锋).Action(new CardAbilityParameter() { GameContext = gameContext, MainCard = servant, MainCardLocation = deskIndex });
            }

            return null;
        }
    }
}