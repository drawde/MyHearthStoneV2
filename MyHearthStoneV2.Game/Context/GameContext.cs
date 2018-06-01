using System.Collections.Generic;
using System.Linq;
using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Aura;
using MyHearthStoneV2.Game.Event;

namespace MyHearthStoneV2.Game.Context
{
    /// <summary>
    /// 游戏环境（游戏上下文）
    /// </summary>
    public class GameContext
    {
        /// <summary>
        /// 游戏ID
        /// </summary>
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
        /// 本局中所有的牌
        /// </summary>
        public IEnumerable<Card> AllCard => Players[0].AllCards.Concat(Players[1].AllCards);

        /// <summary>
        /// 本局中对战的玩家
        /// </summary>
        public List<UserContext> Players { get; set; }

        /// <summary>
        /// 场上的生物牌
        /// </summary>        
        public DeskBoard DeskCards { get; set; }

        /// <summary>
        /// 一共打出了多少张牌
        /// </summary>
        public int CastCardCount { get; set; } = 0;


        public GameStatus GameStatus { get; set; } = GameStatus.无;


        /// <summary>
        /// 累计结算队列数(用于区分不同的队列)
        /// </summary>
        //public int ActionStatementQueueIndex { get; set; } = 0;

        /// <summary>
        /// 当前用户动作结算队列（指的是用户打出一张牌、指定一个随从攻击等动作时，当前游戏环境的卡牌技能触发队列（先入场先触发、等））
        /// </summary>
        public LinkedList<ActionStatement> ActionStatementQueue = new LinkedList<ActionStatement>();

        public LinkedList<IEvent> EventQueue = new LinkedList<IEvent>();

        public LinkedList<IAura> Aurae = new LinkedList<IAura>();

        /// <summary>
        /// 每张牌被打出时将从手牌移到手牌和牌桌之间的过渡位置，在触发完战吼后再从那里移到牌桌
        /// </summary>
        public Card ParachuteCard { get; set; }

        /// <summary>
        /// 每张牌被死亡时将从牌桌移到坟场和牌桌之间的过渡位置，俗称灵车漂移
        /// </summary>
        public LinkedList<Card> HearseCards = new LinkedList<Card>();
    }
}
