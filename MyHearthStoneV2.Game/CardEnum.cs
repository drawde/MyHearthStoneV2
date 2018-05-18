using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game
{
    /// <summary>
    /// 卡牌类型
    /// </summary>
    public enum CardType
    {
        无 = 0,
        随从 = 1,
        法术 = 2,
        装备 = 3,
        英雄 = 4,
    }

    /// <summary>
    /// 场上位置
    /// </summary>
    public enum CardLocation
    {
        不限 = 0,
        牌库 = 1,
        手牌 = 2,
        场上 = 3,
        坟场 = 4,
        降落伞 = 5,
        灵车 = 6
    }

    public enum Rarity
    {
        普通 = 1,
        精良 = 2,
        史诗 = 3,
        传说 = 4,
    }

    /// <summary>
    /// 职业
    /// </summary>
    public enum Profession
    {
        None = 0,
        Neutral = 10,
        Hunter = 1,
        Warlock = 2,
        Warrior = 3,
        Mage = 4,
        Druid = 5,
        Shaman = 6,
        Rogue = 7,
        Paladin = 8,
        Priest = 9
    }

    /// <summary>
    /// 卡牌异能的施放目标（火球术、冰锥术、黑翼腐蚀者、扭曲虚空）
    /// </summary>
    public enum CastStyle
    {
        无 = 0,
        己方随从 = 1,
        己方随从或英雄 = 2,
        敌方随从 = 3,
        敌方随从或英雄 = 4,
        随从 = 5,
        己方英雄 = 7,
        敌方英雄 = 8,
        英雄 = 9,
        无限制 = 10
    }

    /// <summary>
    /// 卡牌施放准心样式
    /// </summary>
    public enum CastCrosshairStyle
    {
        无 = 0,
        单个 = 1,
        范围 = 2,
    }
    

    public enum AbilityType
    {
        无 = 0,
        战吼 = 1,
        亡语 = 2,
        光环 = 3,
        英雄技能 = 4,
        法术 = 5,
        触发 = 6,
        激怒 = 7,
        剧毒 = 8,
        嘲讽 = 9,
        冲锋 = 10,
        光环BUFF = 11,
        BUFF = 12,
        法术强度 = 13,
    }

    /// <summary>
    /// 卡牌行为类型
    /// </summary>
    public enum ActionType
    {
        进场 = 1,
        扣血 = 2,
        攻击 = 3,
        受到伤害 = 4,
        死亡 = 5,
        受到攻击 = 6,
        重置攻击次数 = 7,
        受到治疗 = 8,
        受到法术伤害 = 9,
    }

    /// <summary>
    /// 结算优先级
    /// </summary>
    public enum PriorityOfSettlement
    {
        无 = 0
    }

    /// <summary>
    /// 种族
    /// </summary>
    public enum Race
    {
        无 = 0,
        野兽 = 1,
        恶魔 = 2,
        龙 = 3,
        机械 = 4,
        元素 = 5,
        鱼人 = 6,
        海盗 = 7,
        图腾 = 8,
        兽人 = 9,
    }

    /// <summary>
    /// 挑选方式
    /// </summary>
    public enum PickType
    {
        随机 = 1,
        指定 = 2,
    }

    /// <summary>
    /// 打出这张牌的前置条件
    /// </summary>
    public enum CastCardPrecondition
    {
        无 = 0,
        健康 = 1,
        装备有武器 = 2,
    }

    public enum GameStatus
    {
        无 = 0,
        进行中 = 1,
        先手胜利 = 2,
        后手胜利 = 3,
        平局 = 4
    }
}
