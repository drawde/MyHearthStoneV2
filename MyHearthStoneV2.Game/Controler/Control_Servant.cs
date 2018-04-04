
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

namespace MyHearthStoneV2.Game.Controler
{
    internal partial class Controler_Base
    {
        /// <summary>
        /// 将一名随从从手牌中移到场上
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="cardInGameCode"></param>
        /// <param name="location"></param>
        [ControlerMonitor(AttributePriority = 99), PlayerActionMonitor(AttributePriority = 98), UserActionMonitor(AttributePriority = 1)]
        internal void CastServant(BaseServant servant, int location, int target)
        {
            var user = GameContext.GetActivationUserContext();
            user.Power -= servant.Cost < 0 ? 0 : servant.Cost;
            user.ComboSwitch = true;

            location = GameContext.ShiftServant(location);

            //先从手牌中移除这张牌
            user.HandCards.RemoveAt(user.HandCards.FindIndex(c => c.CardInGameCode == servant.CardInGameCode));

            GameContext.TriggerCardAbility(user.HandCards, SpellCardAbilityTime.己方随从入场, AbilityType.BUFF, servant, target);

            #region 首先触发打出的这张牌的战吼技能
            if (servant.Abilities.Any(c => c.AbilityType == AbilityType.战吼))
            {
                foreach (var ability in servant.Abilities.Where(c => c.AbilityType == AbilityType.战吼))
                {
                    CardAbilityParameter abilityPara = new CardAbilityParameter()
                    {
                        GameContext = GameContext,
                        MainCard = servant,
                        SecondaryCard = target > -1 ? GameContext.DeskCards[target] : null,
                        MainCardLocation = location
                    };
                    ability.Action(abilityPara);
                }
            }
            #endregion

            BaseActionParameter para = CardActionFactory.CreateParameter(servant, GameContext, deskIndex: location);
            GameContext.EventQueue.AddLast(new CastServantEvent() { EventCard = servant, Parameter = para});

            
            //CardActionFactory.CreateAction(servant, ActionType.进场).Action(para);
            //servant.Cast(GameContext, location, target);

            #region 然后触发场内牌的技能
            GameContext.TriggerCardAbility(GameContext.DeskCards.GetDeskCardsByIsFirst(user.IsFirst).Where(c => c != null && c.CardInGameCode != servant.CardInGameCode), SpellCardAbilityTime.己方随从入场, servant, target);
            #endregion
        }


        /// <summary>
        /// 随从攻击进行阶段
        /// </summary>
        /// <param name="servant"></param>
        /// <param name="target"></param>
        [ControlerMonitor(AttributePriority = 99), PlayerActionMonitor(AttributePriority = 98), UserActionMonitor(AttributePriority = 1)]
        internal void ServantAttack(BaseServant servant, int target)
        {
            BaseActionParameter para = CardActionFactory.CreateParameter(servant, GameContext, secondaryCard: GameContext.DeskCards[target]);
            CardActionFactory.CreateAction(servant, ActionType.攻击).Action(para);
            //servant.Attack(GameContext, GameContext.DeskCards[target]);
        }


    }
}
