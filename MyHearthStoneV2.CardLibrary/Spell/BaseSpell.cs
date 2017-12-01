
using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.CardAbility;
using MyHearthStoneV2.CardLibrary.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.Spell
{
    /// <summary>
    /// 法术类卡牌
    /// </summary>
    public abstract class BaseSpell : Card
    {
        public virtual BuffTimeLimit buffTime { get; } = BuffTimeLimit.无限制;
        public virtual CastStyle CastStyle { get; } = CastStyle.无;
        public virtual CastCrosshairStyle CastCrosshairStyle { get; } = CastCrosshairStyle.无;

        public virtual List<SpellCardAbilityTime> LstSpellCardAbilityTime { get; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.无 };

        /// <summary>
        /// 触发卡牌技能
        /// </summary>
        /// <param name="gameContext">游戏环境</param>
        /// <param name="triggerCard">触发这个技能的牌（幸运币(triggerCard) => 紫罗兰教师(sourceCard)）</param>
        /// <param name="sourceCard">持有这个技能的牌（幸运币(triggerCard) => 紫罗兰教师(sourceCard)）</param>
        /// <param name="targetCardIndex">指向类技能的目标卡牌下标</param>
        /// <param name="location">触发这个技能的牌准备进入牌桌上的下标</param>
        /// <returns></returns>
        public abstract void CastAbility(GameContext gameContext, Card triggerCard, Card sourceCard, List<int> targetCardIndex, int location);

        /// <summary>
        /// 打出法术牌
        /// </summary>
        /// <param name="gameContext"></param>
        /// <param name="sourceCard"></param>
        /// <param name="targetCardIndex"></param>
        public abstract void CastSpell(GameContext gameContext, BaseSpell sourceCard, List<int> targetCardIndex);

        /// <summary>
        /// 取消技能效果
        /// </summary>
        /// <param name="gameContext"></param>
        public abstract void DisableAbility(GameContext gameContext);
    }
}
