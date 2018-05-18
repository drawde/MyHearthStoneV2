using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.CardAbility;
using MyHearthStoneV2.Game.Parameter.Hero;
using System.Linq;


namespace MyHearthStoneV2.Game.CardLibrary.CardAction.Hero
{
    /// <summary>
    /// 英雄死亡
    /// </summary>
    public class HeroDeadAction : Action.IGameAction
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            HeroActionParameter para = actionParameter as HeroActionParameter;
            BaseHero baseHero = para.Biology;
            GameContext gameContext = para.GameContext;
            var user = gameContext.GetUserContextByMyCard(baseHero);

            gameContext.DeskCards[user.IsFirst ? 0 : 8] = null;
            baseHero.CardLocation = CardLocation.灵车;
            gameContext.HearseCards.AddLast(baseHero);

            if (baseHero.Abilities.Any(c => c is DeathWhisperDriver<IGameAction, ICardLocationFilter>))
            {
                gameContext.AddActionStatement(baseHero.Abilities.First(), new CardAbilityParameter()
                {
                    GameContext = gameContext,
                    PrimaryCard = baseHero,
                });
            }
            return null;
        }
    }
}
