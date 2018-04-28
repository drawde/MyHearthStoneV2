using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using System.Collections.Generic;
using MyHearthStoneV2.Game.Parameter;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.WarCry.AlterBody
{
    public class REV_JiaoXiaoDeZhongShi : ICardAbility
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.BUFF;
        public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get; set; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.己方回合结束, SpellCardAbilityTime.对方回合结束 };
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            BaseServant card = actionParameter.MainCard as BaseServant;
            card.Damage -= 2;
            if (card.Damage < 0)
            {
                card.Damage = 0;
            }
            //card.Buffs.Remove(card.Buffs.First(c => c.Value is CA_JiaoXiaoDeZhongShi).Key);
            card.Abilities.Remove(this);
            return null;
        }
    }
}