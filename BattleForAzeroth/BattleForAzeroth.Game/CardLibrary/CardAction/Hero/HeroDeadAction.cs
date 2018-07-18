using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.CardLibrary.Hero;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Parameter;
using System.Linq;


namespace BattleForAzeroth.Game.CardLibrary.CardAction.Hero
{
    /// <summary>
    /// 英雄死亡
    /// </summary>
    public class HeroDeadAction : Action.IGameAction
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            ActionParameter para = actionParameter as ActionParameter;
            BaseHero baseHero = para.PrimaryCard as BaseHero;
            GameContext gameContext = para.GameContext;
            var user = gameContext.GetUserContextByMyCard(baseHero);

            gameContext.DeskCards[user.IsFirst ? 0 : 8] = null;
            baseHero.CardLocation = CardLocation.灵车;
            gameContext.HearseCards.AddLast(baseHero);

            if (baseHero.Abilities.Any(c => c is DeathWhisperDriver<IGameAction, ICardLocationFilter>))
            {
                gameContext.AddActionStatement(baseHero.Abilities.First(), new ActionParameter()
                {
                    GameContext = gameContext,
                    PrimaryCard = baseHero,
                });
            }
            return null;
        }
    }
}
