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
        英雄 = 9
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

    /// <summary>
    /// 卡牌技能施放时机
    /// </summary>
    public enum SpellCardAbilityTime
    {
        无 = 0,

        己方回合结束 = 1,
        己方回合开始 = 2,

        己方随从入场 = 3,
        己方随从入坟场 = 4,

        己方英雄攻击 = 5,
        己方英雄受到伤害 = 6,
        己方英雄受到攻击 = 7,
        己方随从攻击 = 8,
        己方随从受到伤害 = 9,
        己方随从受到攻击 = 10,
        
        己方打出法术牌前 = 11,
        己方打出法术牌后 = 12,

        //********************************************************//

        对方回合结束 = 101,
        对方回合开始 = 102,

        对方随从入场 = 103,
        对方随从入坟场 = 104,

        对方英雄攻击 = 105,
        对方英雄受到攻击 = 106,
        对方英雄受到伤害 = 107,
        对方随从攻击 = 108,
        对方随从受到伤害 = 109,
        对方随从受到攻击 = 110,

        对方打出法术牌前 = 111,
        对方打出法术牌后 = 112,

        //********************************************************//
        战吼 = 1000,
        //回合结束 = 1001,
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
    }
}
