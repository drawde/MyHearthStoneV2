using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Servant;
using System.Collections.Generic;
using System.Linq;
namespace MyHearthStoneV2.Game.CardLibrary.CardAction.Servant
{
    /// <summary>
    /// 随从死亡
    /// </summary>
    internal class ServantDeadAction : IGameAction
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            ServantActionParameter para = actionParameter as ServantActionParameter;
            BaseServant servant = para.Biology;
            GameContext gameContext = para.GameContext;
            Card triggerCard = para.SecondaryCard;

            //随从死亡
            if (servant.Life < 1)
            {
                //随从进坟场
                servant.CardLocation = CardLocation.坟场;
                UserContext uc = gameContext.GetUserContextByMyCard(servant);
                uc.GraveyardCards.Add(servant);
                gameContext.DeskCards[gameContext.DeskCards.FindIndex(c => c != null && c.CardInGameCode == servant.CardInGameCode)] = null;

                gameContext.TriggerCardAbility(new List<Card>() { servant }, AbilityType.亡语, triggerCard, servant.DeskIndex);
                gameContext.TriggerCardAbility(gameContext.DeskCards.GetDeskCardsByEnemyCard(servant), SpellCardAbilityTime.对方随从入坟场, triggerCard, servant.DeskIndex);
            }

            return null;
        }
    }
}
