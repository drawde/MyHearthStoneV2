using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    /// <summary>
    /// 风怒
    /// </summary>
    public class Windfury : BaseCardAbility
    {
        public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get;  set; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.重置攻击次数 };
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            BaseBiology bb = actionParameter.MainCard as BaseBiology;
            bb.RemainAttackTimes = 2;
            return null;
        }
    }
}
