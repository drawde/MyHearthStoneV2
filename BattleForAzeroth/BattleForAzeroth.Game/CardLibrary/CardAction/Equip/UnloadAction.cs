using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.CardLibrary.Hero;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Parameter;
using System.Linq;

namespace BattleForAzeroth.Game.CardLibrary.CardAction.Equip
{
    /// <summary>
    /// 拆卸装备，如果装备耐久小于1的话
    /// </summary>
    public class UnloadAction : Action.IGameAction
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            GameContext gameContext = actionParameter.GameContext;
            BaseHero baseHero = gameContext.DeskCards.GetHeroByIsFirst(gameContext.GetUserContextByMyCard(actionParameter.Equip).IsFirst);

            baseHero.Equip.CardLocation = CardLocation.灵车;
            gameContext.HearseCards.AddLast(baseHero.Equip);

            if (baseHero.Equip.Abilities.Any(c => c is DeathWhisperDriver<IGameAction, ICardLocationFilter>))
            {
                gameContext.AddActionStatement(baseHero.Equip.Abilities.First(), new ActionParameter()
                {
                    GameContext = gameContext,
                    PrimaryCard = baseHero.Equip,
                });
            }
            baseHero.Equip = null;

            return null;
        }
    }
}
