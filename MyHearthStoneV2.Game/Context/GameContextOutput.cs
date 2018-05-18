using MyHearthStoneV2.Game.CardLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.Context
{
    /// <summary>
    /// 游戏环境上下文（用于输出）
    /// </summary>
    public class GameContextOutput
    {
        public string GameCode { get; set; }


        /// <summary>
        /// 当前回合剩余秒数
        /// </summary>
        public int CurrentTurnRemainingSecond { get; set; }

        /// <summary>
        /// 进行完的回合数
        /// </summary>
        public int TurnIndex { get; set; }

        /// <summary>
        /// 当前回合编码
        /// </summary>
        public string CurrentTurnCode { get; set; }

        /// <summary>
        /// 下个回合编码
        /// </summary>
        public string NextTurnCode { get; set; }
        /// <summary>
        /// 本局中对战的玩家
        /// </summary>
        public List<BaseUserContext> Players { get; set; } = new List<BaseUserContext>();

        /// <summary>
        /// 场上的生物牌
        /// </summary>        
        public List<BaseBiology> DeskCards { get; set; }

        /// <summary>
        /// 一共打出了多少张牌
        /// </summary>
        public int CastCardCount { get; set; } = 0;

        public GameStatus GameStatus { get; set; } = GameStatus.无;
    }
}
