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
    /// 己方回合开始
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class MyTurnStartDriver<T> : IDriver<T> where T : Action.IGameAction
    {
        public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get; set; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.己方回合开始 };        
    }
}
