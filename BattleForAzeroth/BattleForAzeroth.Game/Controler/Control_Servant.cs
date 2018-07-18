
using BattleForAzeroth.Game.Context;

using BattleForAzeroth.Game.CardLibrary.Servant;
using BattleForAzeroth.Game.CardLibrary.CardAction.Servant;
using BattleForAzeroth.Game.Parameter;
using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.Event.Player;

namespace BattleForAzeroth.Game.Controler
{
    public partial class Controler_Base
    {
        /// <summary>
        /// 将一名随从从手牌中移到场上
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="cardInGameCode"></param>
        /// <param name="location"></param>
        public void CastServant(BaseServant servant, int location, int target)
        {
            var user = GameContext.GetActivationUserContext();
            user.Power -= servant.Cost < 0 ? 0 : servant.Cost;
            user.ComboSwitch = true;

            location = GameContext.AutoShiftServant(GameContext.ShiftServant(location));
            GameContext.ParachuteCard = servant;
            servant.CardLocation = CardLocation.降落伞;

            ActionParameter para = new ActionParameter()
            {
                PrimaryCard = servant,
                GameContext = GameContext,
                DeskIndex = location,
                SecondaryCard = target > -1 ? GameContext.DeskCards[target] : null
            };
            var cardAbilityParameter = new ActionParameter()
            {
                GameContext = GameContext,
                PrimaryCard = servant,
                SecondaryCard = target > -1 ? GameContext.DeskCards[target] : null,
                PrimaryCardIndex = location,
            };
            new BattlecryEvent() { EventCard = servant, Parameter = cardAbilityParameter }.Settlement();
            GameContext.QueueSettlement();

            new CastServantAction().Action(para);
            GameContext.ParachuteCard = null;
            GameContext.AddEndOfPlayerActionEvent();
            GameContext.EventQueueSettlement();
            GameContext.QueueSettlement();
        }


        /// <summary>
        /// 随从攻击进行阶段
        /// </summary>
        /// <param name="servant"></param>
        /// <param name="target"></param>
        public void ServantAttack(BaseServant servant, int target)
        {
            ActionParameter para = new ActionParameter()
            {
                PrimaryCard = servant,
                GameContext = GameContext,
                SecondaryCard = GameContext.DeskCards[target]
            };
            CardActionFactory.CreateAction(servant, ActionType.攻击).Action(para);
            Settlement();
        }
    }
}
