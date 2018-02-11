using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Parameter;
using System;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver
{
    /// <summary>
    /// 战吼
    /// </summary>
    /// <typeparam name="G"></typeparam>
    internal class BattlecryDriver<G> : BaseDriver<G> where G : Action.IGameAction
    {
        public override AbilityType AbilityType => AbilityType.战吼;
    }
}
