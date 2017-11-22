using MyHearthStoneV2.CardLibrary.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.Model;
namespace MyHearthStoneV2.CardLibrary.Context
{
    /// <summary>
    /// 游戏环境（游戏上下文）
    /// </summary>
    public class GameContext
    {
        /// <summary>
        /// 本局中所有的牌
        /// </summary>
        public List<Card> AllCard { get; set; }

        /// <summary>
        /// 本局中对战的玩家
        /// </summary>
        public List<UserCards> Players { get; set; }
    }
}
