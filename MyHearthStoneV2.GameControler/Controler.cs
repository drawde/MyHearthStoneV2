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
        private Chessboard chessboard;
        private hs_users firstPlayer;
        private hs_users secondPlayer;
        /// <summary>
        /// 当前回合玩家
        /// </summary>
        private hs_users currentPlayer;

        /// <summary>
        /// 当前回合剩余秒数
        /// </summary>
        private int currentRoundRemainingSecond;

        /// <summary>
        /// 进行完的回合数
        /// </summary>
        private int roundCount = 0;
        public void GameStart(string firstPlayer, string secondPlayer)
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
