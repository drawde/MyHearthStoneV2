using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardEnum
{
    /// <summary>
    /// 场上位置
    /// </summary>
    public enum CardLocation
    {
        牌库 = 1,
        手牌 = 2,
        场上 = 3,
        坟场 = 4
    }

    public enum Rarity
    {
        普通 = 1,
        精良 = 2,
        史诗 = 3,
        传说 = 4,
    }

    /// <summary>
    /// BUFF持续时间
    /// </summary>
    public enum BuffTimeLimit
    {
        己方回合开始 = 1,
        己方回合结束 = 2,
        对方回合开始 = 3,
        对方回合结束 = 4,

        无限制 = 5,

        循环己方回合开始 = 6,
        循环己方回合结束 = 7,
        循环对方回合开始 = 8,
        循环对方回合结束 = 9,
    }

    public enum SpecialEffectTrigger
    {
        随从攻击时
    }

    /// <summary>
    /// 职业
    /// </summary>
    public enum Profession
    {
        猎人 = 1,
        术士 = 2,
        战士 = 3,
        法师 = 4,
        德鲁伊 = 5,
        萨满 = 6,
        盗贼 = 7,
        圣骑士 = 8,
        牧师 = 9
    }

    /// <summary>
    /// 卡牌异能的施放方式（火球术、冰锥术、黑翼腐蚀者、扭曲虚空）
    /// </summary>
    public enum CastStyle
    {
        无 = 0,
        己方随从 = 1,
        己方随从或英雄 = 2,
        敌方随从 = 3,
        敌方随从或英雄 = 4,
    }
}
