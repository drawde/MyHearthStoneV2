using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.WarCry.AlterBody
{
    public class REV_JiaoXiaoDeZhongShi : CA_JiaoXiaoDeZhongShi
    {
        public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.己方回合结束, SpellCardAbilityTime.对方回合结束 };
        public override void CastAbility(GameContext gameContext, Card triggerCard, Card sourceCard, int targetCardIndex, int location)
        {
            BaseServant card = sourceCard as BaseServant;
            card.Damage -= 2;
            //card.Buffs.Remove(card.Buffs.First(c => c.Value is CA_JiaoXiaoDeZhongShi).Key);
            card.Abilities.Remove(this);
        }
    }
}