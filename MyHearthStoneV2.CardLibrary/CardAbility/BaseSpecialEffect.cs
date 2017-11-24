using MyHearthStoneV2.CardEnum;
using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.CardAbility
{
    public abstract class BaseSpecialEffect
    {
        public virtual BuffTimeLimit buffTime { get; } = BuffTimeLimit.无限制;
        public virtual CastStyle CastStyle { get; } = CastStyle.无;
        public virtual CastCrosshairStyle CastCrosshairStyle { get; } = CastCrosshairStyle.无;

        public virtual List<SpellCardAbilityTime> LstSpellCardAbilityTime { get; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.无 };

        public virtual bool CanItTrigger(GameContext gameContext, Card triggerCard) => false;

        /// <summary>
        /// 触发卡牌技能
        /// </summary>
        /// <param name="gameContext"></param>
        /// <param name="targetCardIndex"></param>
        /// <returns></returns>
        public abstract void CastAbility(GameContext gameContext, List<int> targetCardIndex);
    }
}
