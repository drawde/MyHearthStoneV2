using MyHearthStoneV2.Game.Action;
using System;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver
{
    /// <summary>
    /// 光环驱动器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class AuraDriver<T, CT> : BaseDriver<T> where T : IGameAction where CT : List<SpellCardAbilityTime>
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.光环;

        public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get; set; } = Activator.CreateInstance<CT>();
    }
}
