using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary
{
    /// <summary>
    /// 卡牌基类接口
    /// </summary>
    public abstract class Card
    {
        /// <summary>
        /// 费用
        /// </summary>
        public virtual int Cost { get; set; }


        /// <summary>
        /// 初始费用
        /// </summary>
        public virtual int InitialCost { get; set; }

        /// <summary>
        /// 卡牌在一局游戏中的编号
        /// </summary>
        public virtual string CardInGameCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { get; }

        /// <summary>
        /// 卡牌描述
        /// </summary>
        public virtual string Describe { get; }
        /// <summary>
        /// 稀有程度
        /// </summary>
        public virtual Rarity Rare { get; }

        public virtual CardLocation CardLocation { get; set; } = CardLocation.牌库;

        /// <summary>
        /// 卡牌编码
        /// </summary>
        public virtual string CardCode { get; set; }

        /// <summary>
        /// 是否是某张牌的衍生物（如鬼灵爬行者 => 鬼灵蜘蛛）
        /// </summary>
        public virtual bool IsDerivative { get; } = false;

        /// <summary>
        /// 卡牌技能
        /// </summary>
        public virtual List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>();

        public virtual CardType CardType { get; set; } = CardType.无;

        public virtual string BackgroudImage { get; set; } = "/images/baraja/1.jpg";

        /// <summary>
        /// 当前这张牌在当前游戏环境中的打出顺序（用于结算队列）
        /// </summary>
        public virtual int CastIndex { get; set; } = 0;
    }
}
