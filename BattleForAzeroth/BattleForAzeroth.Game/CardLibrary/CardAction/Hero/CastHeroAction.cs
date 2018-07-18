using BattleForAzeroth.Game.CardLibrary.Hero;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Parameter;

using System.Linq;

namespace BattleForAzeroth.Game.CardLibrary.CardAction.Hero
{
    /// <summary>
    /// 英雄进场（不触发技能，比如召唤出来的随从）
    /// </summary>
    public class CastHeroAction : Action.IGameAction
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            ActionParameter para = actionParameter as ActionParameter;
            BaseHero baseHero = para.PrimaryCard as BaseHero;
            GameContext gameContext = para.GameContext;
            var user = gameContext.GetUserContextByMyCard(baseHero);

            gameContext.CastCardCount++;
            baseHero.CastIndex = gameContext.CastCardCount;
            baseHero.CardLocation = CardLocation.场上;
            baseHero.DeskIndex = para.DeskIndex;
            
            new HeroDeadAction().Action(new ActionParameter()
            {
                PrimaryCard = baseHero,
                GameContext = gameContext
            });
            
            gameContext.DeskCards[user.IsActivation ? 0 : 8] = baseHero;
            return null;
        }
    }
}
