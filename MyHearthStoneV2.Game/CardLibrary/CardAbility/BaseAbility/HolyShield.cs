using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    /// <summary>
    /// 圣盾
    /// </summary>
    public class HolyShield : IBaseCardAbility
    {
        public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get; set; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.己方随从受到伤害前 };
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            //BaseBiology bb = sourceCard as BaseBiology;
            actionParameter.MainCard.Abilities.RemoveAt(actionParameter.MainCard.Abilities.FindIndex(c => c == this));
            return null;
        }
    }
}
