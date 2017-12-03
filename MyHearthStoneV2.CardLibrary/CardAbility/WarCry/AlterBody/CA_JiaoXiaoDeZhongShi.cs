
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
    public class CA_JiaoXiaoDeZhongShi : BaseCardAbility
    {
        public override BuffTimeLimit buffTime { get; } = BuffTimeLimit.己方回合结束;
        public override CastStyle CastStyle { get; } = CastStyle.随从;
        public override CastCrosshairStyle CastCrosshairStyle { get; } = CastCrosshairStyle.单个;

        public override List<SpellCardAbilityTime> LstSpellCardAbilityTime { get; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.己方随从入场 };
        public override void CastAbility(GameContext gameContext, Card triggerCard, Card sourceCard, List<int> targetCardIndex, int location)
        {
            if (targetCardIndex != null && targetCardIndex.Count == 1 && targetCardIndex[0] != 0 && targetCardIndex[0] != 8)
            {
                int idx = targetCardIndex[0];
                BaseServant card = gameContext.GetCardByLocation(idx) as BaseServant;
                card.Damage += 2;
                card.Buffs.Add(sourceCard, new REV_JiaoXiaoDeZhongShi());
            }
        }
    }
}
