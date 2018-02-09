using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Hero;
using System.Linq;

namespace MyHearthStoneV2.Game.CardLibrary.CardAction.Hero
{
    /// <summary>
    /// 英雄进场（不触发技能，比如召唤出来的随从）
    /// </summary>
    internal class CastHeroAction : Action.IGameAction
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            HeroActionParameter para = actionParameter as HeroActionParameter;
            BaseHero baseHero = para.Biology;
            GameContext gameContext = para.GameContext;

            var user = gameContext.GetUserContextByMyCard(baseHero);
            gameContext.CastCardCount++;
            baseHero.CastIndex = gameContext.CastCardCount;
            baseHero.CardLocation = CardLocation.场上;
            baseHero.DeskIndex = para.DeskIndex;
            BaseHero currentHero = gameContext.GetHeroByActivation(user.IsActivation);
            gameContext.DeskCards[user.IsFirst ? 0 : 8] = null;

            currentHero.CardLocation = CardLocation.坟场;
            currentHero = baseHero;



            if (user.HandCards.Any(c => c == baseHero))
            {
                user.HandCards.Remove(baseHero);
            }
            else if (user.StockCards.Any(c => c == baseHero))
            {
                user.StockCards.Remove(baseHero);
            }
            gameContext.DeskCards[user.IsActivation ? 0 : 8] = baseHero;
            return null;
        }
    }
}
