using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Game;
using MyHearthStoneV2.GameControler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.GameControler
{
    public class ControllerProxy
    {
        private static List<Controler> lstCtl = new List<Controler>();
        public static Controler CtlInstance(string gameID)
        {
            return lstCtl.First(c => c.GameID == gameID);
        }
        /// <summary>
        /// 创建一局游戏
        /// </summary>
        /// <param name="firstPlayer">先手玩家</param>
        /// <param name="secondPlayer">后手玩家</param>
        /// <param name="fristCardGroupID">先手玩家卡组</param>
        /// <param name="secondCardGroupID">后手玩家卡组</param>
        /// <returns>游戏ID</returns>
        public static string CreateGame(string firstPlayer, string secondPlayer, int fristCardGroupID, int secondCardGroupID)
        {
            string gameID = SignUtil.CreateSign(firstPlayer);
            Controler ctl = new Controler();
            ctl.GameID = gameID;
            ctl.chessboard = new Chessboard();

            return gameID;
        }
    }
}
