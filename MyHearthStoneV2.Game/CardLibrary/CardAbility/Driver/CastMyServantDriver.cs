using MyHearthStoneV2.Game.Action;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver
{
    /// <summary>
    /// 己方随从入场驱动器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class CastMyServantDriver<T> : BaseDriver<T> where T : IGameAction
    {
        public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get; set; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.己方随从入场 };
    }
}
