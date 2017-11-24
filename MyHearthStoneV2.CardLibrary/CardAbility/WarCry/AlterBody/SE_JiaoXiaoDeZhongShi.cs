using MyHearthStoneV2.CardEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.CardLibrary.Context;
using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.Servant;

namespace MyHearthStoneV2.CardLibrary.CardAbility.WarCry.AlterBody
{
    public class SE_JiaoXiaoDeZhongShi : BaseSpecialEffect
    {
        public override BuffTimeLimit buffTime { get; } = BuffTimeLimit.己方回合结束;
        public override CastStyle CastStyle { get; } = CastStyle.随从;
        public override CastCrosshairStyle CastCrosshairStyle { get; } = CastCrosshairStyle.单个;

        public override List<SpellCardAbilityTime> LstSpellCardAbilityTime { get; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.入场 };
        public override void CastAbility(GameContext gameContext, List<int> targetCardIndex)
        {
            if (targetCardIndex != null && targetCardIndex.Count == 1 && targetCardIndex[0] > -1 && targetCardIndex[0] < 14)
            {
                int idx = targetCardIndex[0];
                BaseServant card = gameContext.Players.First(c => c.IsFirst == idx < 7).DeskCards[idx] as BaseServant;
                card.Damage += 2;
            }            
        }
    }
}
