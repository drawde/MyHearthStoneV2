using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.CardLibrary.Servant;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Parameter;
using System.Linq;
namespace BattleForAzeroth.Game.CardLibrary.CardAction.Servant
{
    /// <summary>
    /// 随从死亡
    /// </summary>
    public class ServantDeadAction : Action.IGameAction
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            BaseServant servant = actionParameter.PrimaryCard as BaseServant;
            GameContext gameContext = actionParameter.GameContext;
            Card triggerCard = actionParameter.SecondaryCard;

            //随从死亡
            if (servant.Life < 1 || servant.IsDeathing)
            {
                servant.CardLocation = CardLocation.灵车;
                gameContext.DeskCards[servant.DeskIndex] = null;
                gameContext.HearseCards.AddLast(servant);

                if (servant.Abilities.Any(c => c is DeathWhisperDriver<IGameAction, ICardLocationFilter>))
                {
                    gameContext.AddActionStatement(servant.Abilities.First(), new ActionParameter()
                    {
                        GameContext = gameContext,
                        PrimaryCard = servant,
                        SecondaryCard = triggerCard,
                    });                    
                }
            }            
            return null;
        }
    }
}
