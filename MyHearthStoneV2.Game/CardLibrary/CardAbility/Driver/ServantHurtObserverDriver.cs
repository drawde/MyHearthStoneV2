using MyHearthStoneV2.Game.Action;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver
{
    internal class ServantHurtObserverDriver<G> : IDriver<G> where G : IGameAction
    {
        public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get; set; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.随从受伤 };
    }
}
