using System.Collections.Generic;
using MyHearthStoneV2.Game.CardLibrary;

namespace MyHearthStoneV2.Game.Context
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
        public List<UserContext> Players { get; set; }

        /// <summary>
        /// 场上的生物牌
        /// </summary>        
        public List<BaseBiology> DeskCards { get; set; }

        /// <summary>
        /// 当前用户动作结算队列（指的是用户打出一张牌、指定一个随从攻击等动作时，当前游戏环境的卡牌技能触发队列（先入场先触发、等））
        /// </summary>
        public LinkedList<Card> CurrentActionStatement = new LinkedList<Card>();
    }
}
