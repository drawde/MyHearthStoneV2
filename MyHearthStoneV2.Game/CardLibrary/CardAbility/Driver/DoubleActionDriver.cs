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
    /// 双技能驱动
    /// </summary>
    /// <typeparam name="G1"></typeparam>
    /// <typeparam name="G2"></typeparam>
    internal class DoubleActionDriver<G1, G2> : BaseDriver<G1> where G1 : IGameAction where G2 : IGameAction
    {
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            Activator.CreateInstance<G1>().Action(actionParameter);
            Activator.CreateInstance<G2>().Action(actionParameter);
            return null;
        }
    }
}
