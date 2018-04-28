using MyHearthStoneV2.Game.CardLibrary.CardAbility.AbilityAttribute;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Parameter;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    /// <summary>
    /// 风怒
    /// </summary>
    public class Windfury : DefaultAttribute, ICardAbility
    {
        public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get;  set; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.重置攻击次数 };
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            BaseBiology bb = actionParameter.MainCard as BaseBiology;
            bb.RemainAttackTimes = 2;
            return null;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
