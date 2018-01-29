using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    /// <summary>
    /// 嘲讽
    /// </summary>
    public class Taunt : BaseCardAbility
    {
        public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get; set; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.己方随从入场 };
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            return null;
        }        
    }
}
