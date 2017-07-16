using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Game;
using MyHearthStoneV2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.GameControler
{
    /// <summary>
    /// 游戏控制器
    /// </summary>
    public class Controler
    {
        /// <summary>
        /// 游戏ID
        /// </summary>
        public string GameID { get; set; }
        internal Controler()
        {
            
        }
        internal Chessboard chessboard;
        internal HS_Users firstPlayer;
        internal HS_Users secondPlayer;
        /// <summary>
        /// 当前回合玩家
        /// </summary>
        internal HS_Users currentPlayer;

        /// <summary>
        /// 当前回合剩余秒数
        /// </summary>
        internal int currentRoundRemainingSecond;

        /// <summary>
        /// 进行完的回合数
        /// </summary>
        private int roundCount = 0;

        

        public void GameStart()
        {
        }

        public void RoundEnd(string player)
        {
        }
        public void RoundStart(string player)
        {
        }
    }
}
