using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver
{
    /// <summary>
    /// 受伤
    /// </summary>
    /// <typeparam name="G"></typeparam>
    internal class HurtDriver<G> : IDriver<G> where G : Action.IGameAction
    {
        public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get; set; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.受伤 };
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            Activator.CreateInstance<G>().Action(actionParameter);
            return null;
        }
    }
}
