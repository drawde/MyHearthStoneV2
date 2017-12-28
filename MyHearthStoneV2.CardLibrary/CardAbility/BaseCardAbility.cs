
using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.CardAbility
{
    public abstract class BaseCardAbility
    {
        public virtual BuffTimeLimit BuffTime { get; } = BuffTimeLimit.无限制;
        public virtual CastStyle CastStyle { get; } = CastStyle.无;
        public virtual CastCrosshairStyle CastCrosshairStyle { get; } = CastCrosshairStyle.无;

        public virtual List<SpellCardAbilityTime> LstSpellCardAbilityTime { get; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.无 };

        //public virtual bool CanItTrigger(GameContext gameContext, Card triggerCard) => false;



        /// <summary>
        /// 触发卡牌技能
        /// </summary>
        /// <param name="gameContext">游戏环境</param>
        /// <param name="triggerCard">触发这个技能的牌（幸运币(triggerCard) => 紫罗兰教师(sourceCard)）</param>
        /// <param name="sourceCard">持有这个技能的牌（幸运币(triggerCard) => 紫罗兰教师(sourceCard)）</param>
        /// <param name="targetCardIndex">指向类技能的目标卡牌下标</param>
        /// <param name="location">触发这个技能的牌准备进入牌桌上的下标</param>
        /// <returns></returns>
        public abstract void CastAbility(GameContext gameContext, Card triggerCard, Card sourceCard, int targetCardIndex, int location = -1);        
    }
}
