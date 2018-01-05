using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.Context;
using System.Collections.Generic;
using MyHearthStoneV2.Game.Controler;
using System.Linq;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.CardLibrary.Hero;

namespace MyHearthStoneV2.Game.CardLibrary
{
    /// <summary>
    /// 生物牌（随从、英雄）
    /// </summary>
    public abstract class BaseBiology : Card
    {
        /// <summary>
        /// 初始生命值
        /// </summary>
        public virtual int InitialLife { get; set; }

        /// <summary>
        /// 初始伤害
        /// </summary>
        public virtual int InitialDamage { get; set; }


        /// <summary>
        /// 生命值
        /// </summary>
        public virtual int Life { get; set; }

        /// <summary>
        /// 攻击力
        /// </summary>
        public virtual int Damage { get; set; }        

        /// <summary>
        /// 当前回合剩余攻击次数
        /// </summary>
        public virtual int RemainAttackTimes { get; set; }

        /// <summary>
        /// 在牌桌上的位置
        /// </summary>
        public virtual int DeskIndex { get; set; } = -1;

        ///// <summary>
        ///// 被攻击
        ///// </summary>
        //public virtual void UnderAttack(GameContext gameContext, BaseBiology attackCard)
        //{
        //    if (attackCard.Abilities.Any(c => c.SpellCardAbilityTimes.Any(x => x == SpellCardAbilityTime.己方随从受到伤害后)))
        //    {
        //        var abiliti = attackCard.Abilities.First(c => c.SpellCardAbilityTimes.Any(x => x == SpellCardAbilityTime.己方随从受到伤害后));
        //        abiliti.CastAbility(gameContext, attackCard, this, 0, DeskIndex);
        //    }
        //    else
        //    {
        //        gameContext.BiologyByDamege(attackCard, attackCard.Damage, DeskIndex);
        //    }
        //}

        ///// <summary>
        ///// 攻击一个随从或英雄
        ///// </summary>
        ///// <param name="gameContext"></param>
        ///// <param name="targetCard"></param>
        //public virtual void Attack(GameContext gameContext, BaseBiology targetCard)
        //{            
        //    int trueDamege = Damage;
        //    if (targetCard is BaseHero)
        //    {
        //        gameContext.BiologyByDamege(this, trueDamege, targetCard.DeskIndex);
        //    }
        //    else
        //    {
        //        UnderAttack(gameContext, targetCard);
        //    }
        //    RemainAttackTimes -= 1;
        //}
    }
}
