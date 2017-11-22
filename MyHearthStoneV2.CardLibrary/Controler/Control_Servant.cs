using MyHearthStoneV2.CardEnum;
using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.Context;
using MyHearthStoneV2.CardLibrary.Monitor;
using MyHearthStoneV2.CardLibrary.Servant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.Controler
{
    public partial class Controler_Base
    {
        /// <summary>
        /// 将一名随从从手牌中移到场上
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="cardInGameCode"></param>
        /// <param name="location"></param>
        [ControlerMonitor, PlayerActionMonitor]
        public void CastServant(UserCards user, BaseServant card, int location)
        {
            user.Power -= card.Cost;
            card.CardLocation = CardLocation.场上;
            user.DeskCards[location] = card;
        }
    }
}
