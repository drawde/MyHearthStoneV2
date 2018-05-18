using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.CardAbility;
using MyHearthStoneV2.Game.Parameter.Servant;
using System.Collections.Generic;
using System.Linq;
namespace MyHearthStoneV2.Game.CardLibrary.CardAction.Servant
{
    /// <summary>
    /// 随从死亡
    /// </summary>
    public class ServantDeadAction : Action.IGameAction
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            ServantActionParameter para = actionParameter as ServantActionParameter;
            BaseServant servant = para.Servant;
            GameContext gameContext = para.GameContext;
            Card triggerCard = para.SecondaryCard;

            //随从死亡
            if (servant.Life < 1 || servant.IsDeathing)
            {
                //UserContext uc = gameContext.GetUserContextByMyCard(servant);

                servant.CardLocation = CardLocation.灵车;
                gameContext.DeskCards[servant.DeskIndex] = null;
                gameContext.HearseCards.AddLast(servant);

                if (servant.Abilities.Any(c => c is DeathWhisperDriver<IGameAction, ICardLocationFilter>))
                {
                    gameContext.AddActionStatement(servant.Abilities.First(), new CardAbilityParameter()
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
