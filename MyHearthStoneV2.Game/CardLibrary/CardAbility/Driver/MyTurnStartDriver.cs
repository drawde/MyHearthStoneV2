using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver
{
    /// <summary>
    /// 己方回合开始
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class MyTurnStartDriver<T> : BaseDriver<T> where T : Action.IGameAction
    {
        public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get; set; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.己方回合开始 };        
    }
}
