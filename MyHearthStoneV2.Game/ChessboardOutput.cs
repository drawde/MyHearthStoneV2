using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game
{
    /// <summary>
    /// 棋盘对象（用于输出）
    /// </summary>
    public class ChessboardOutput
    {
        public string GameCode { get; set; }
        /// <summary>
        /// 本局中对战的玩家
        /// </summary>
        public List<BaseUserCards> Players { get; set; }
    }
}
