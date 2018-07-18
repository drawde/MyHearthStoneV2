using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.CardLibrary.Servant;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Event.Player;
using BattleForAzeroth.Game.Event.Servant;
using BattleForAzeroth.Game.Event.Trigger;
using BattleForAzeroth.Game.Parameter;


using System.Linq;
namespace BattleForAzeroth.Game.CardLibrary.CardAction.Servant
{
    /// <summary>
    /// 随从进场（不触发技能，比如召唤出来的随从）
    /// </summary>
    public class CastServantAction : IGameAction
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            BaseServant servant = actionParameter.PrimaryCard as BaseServant;
            GameContext gameContext = actionParameter.GameContext;
            BaseBiology attackCard = actionParameter.SecondaryCard as BaseBiology;
            int deskIndex = actionParameter.DeskIndex;

            var user = gameContext.GetUserContextByMyCard(servant);
            gameContext.CastCardCount++;
            servant.CastIndex = gameContext.CastCardCount;
            servant.CardLocation = CardLocation.场上;
            servant.DeskIndex = deskIndex;
            servant.CanAttack = true;

            gameContext.DeskCards[deskIndex] = servant;

            if (servant.HasCharge)
            {
                new ResetServantRemainAttackTimes().Action(actionParameter);                
            }
            gameContext.EventQueue.AddLast(new ServantInDeskEvent() { EventCard = servant, Parameter = actionParameter });
            gameContext.EventQueue.AddLast(new MyServantCastedEvent() { EventCard = servant, Parameter = actionParameter });
            gameContext.EventQueue.AddLast(new PrimaryPlayerPlayCardEvent() { EventCard = servant, Parameter = actionParameter });
            return null;
        }

        
    }
}