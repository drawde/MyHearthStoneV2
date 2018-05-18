
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Monitor;
using System.Linq;
using System.Collections.Generic;
using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.CardLibrary.CardAction;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Servant;
using MyHearthStoneV2.Game.Parameter.CardAbility;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Event.Player;
using MyHearthStoneV2.Game.Event.Trigger;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;

namespace MyHearthStoneV2.Game.Controler
{
    public partial class Controler_Base
    {
        /// <summary>
        /// 将一名随从从手牌中移到场上
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="cardInGameCode"></param>
        /// <param name="location"></param>
        [ControlerMonitor(AttributePriority = 99), PlayerActionMonitor(AttributePriority = 98), UserActionMonitor(AttributePriority = 1)]
        public void CastServant(BaseServant servant, int location, int target)
        {
            var user = GameContext.GetActivationUserContext();
            user.Power -= servant.Cost < 0 ? 0 : servant.Cost;
            user.ComboSwitch = true;

            location = GameContext.AutoShiftServant(GameContext.ShiftServant(location));            
            //先从手牌中移除这张牌
            user.HandCards.RemoveAt(user.HandCards.FindIndex(c => c.CardInGameCode == servant.CardInGameCode));
            GameContext.ParachuteCard = servant;
            servant.CardLocation = CardLocation.降落伞;

            BaseActionParameter para = CardActionFactory.CreateParameter(servant, GameContext, deskIndex: location, secondaryCard: target > -1 ? GameContext.DeskCards[target] : null);
            if (servant.Abilities.Any(c => c is BaseBattlecryDriver<IGameAction, ICardLocationFilter>))
            {
                servant.Abilities.First().Action(para);
            }            
            //GameContext.EventQueue.AddLast(new BattlecryEvent() { EventCard = servant, Parameter = para });
            
            new CastServantAction().Action(para);
            GameContext.ParachuteCard = null;
        }


        /// <summary>
        /// 随从攻击进行阶段
        /// </summary>
        /// <param name="servant"></param>
        /// <param name="target"></param>
        [ControlerMonitor(AttributePriority = 99), PlayerActionMonitor(AttributePriority = 98), UserActionMonitor(AttributePriority = 1)]
        public void ServantAttack(BaseServant servant, int target)
        {
            BaseActionParameter para = CardActionFactory.CreateParameter(servant, GameContext, secondaryCard: GameContext.DeskCards[target]);
            CardActionFactory.CreateAction(servant, ActionType.攻击).Action(para);
            //servant.Attack(GameContext, GameContext.DeskCards[target]);
        }


    }
}
