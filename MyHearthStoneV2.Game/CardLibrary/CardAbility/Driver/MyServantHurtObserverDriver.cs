using MyHearthStoneV2.Game.Action;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver
{
    /// <summary>
    /// 每当己方随从受到伤害驱动器
    /// </summary>
    /// <typeparam name="G"></typeparam>
    internal class MyServantHurtObserverDriver<G> : BaseDriver<G> where G : IGameAction
    {
        public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get; set; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.己方随从受到伤害后 };
    }
}
