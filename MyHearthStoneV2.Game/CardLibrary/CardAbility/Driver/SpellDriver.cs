using MyHearthStoneV2.Game.Action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver
{
    /// <summary>
    /// 法术驱动器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class SpellDriver<T> : IDriver<T> where T : Action.IGameAction
    {        

    }
}
