using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Parameter;
using System;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver
{
    /// <summary>
    /// 亡语驱动器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class DeathWhisperDriver<T> : IDriver<T> where T : Action.IGameAction
    {
        public override AbilityType AbilityType => AbilityType.亡语;
    }
}
