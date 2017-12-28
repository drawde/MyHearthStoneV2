
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.CardLibrary.Context;
using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.Servant;
using MyHearthStoneV2.CardLibrary.Controler;
namespace MyHearthStoneV2.CardLibrary.CardAbility.WarCry.AlterBody
{
    public class CA_JiaoXiaoDeZhongShi : BaseCardAbility
    {
        public override BuffTimeLimit BuffTime { get; } = BuffTimeLimit.己方回合结束;
        public override CastStyle CastStyle { get; } = CastStyle.随从;
        public override CastCrosshairStyle CastCrosshairStyle { get; } = CastCrosshairStyle.单个;

        public override List<SpellCardAbilityTime> LstSpellCardAbilityTime { get; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.战吼 };
        public override void CastAbility(GameContext gameContext, Card triggerCard, Card sourceCard, int targetCardIndex, int location)
        {
            if (targetCardIndex > -1 && targetCardIndex != 0 && targetCardIndex != 8)
            {
                BaseServant card = gameContext.GetCardByLocation(targetCardIndex) as BaseServant;
                card.Damage += 2;
                card.Buffs.Add(sourceCard, new REV_JiaoXiaoDeZhongShi());
            }
        }
    }
}
