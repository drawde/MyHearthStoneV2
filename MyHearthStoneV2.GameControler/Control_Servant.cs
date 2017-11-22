using MyHearthStoneV2.CardEnum;
using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.Servant;
using MyHearthStoneV2.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.GameControler
{
    internal partial class Controler
    {
        /// <summary>
        /// 将一名随从从手牌中移到场上
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="cardInGameCode"></param>
        /// <param name="location"></param>
        [ControlerMonitor, PlayerActionMonitor]
        internal void CastServant(UserCards user, BaseServant card, int location)
        {
            user.Power -= card.Cost;
            card.CardLocation = CardLocation.场上;
            user.DeskCards[location] = card;
        }
    }
}
