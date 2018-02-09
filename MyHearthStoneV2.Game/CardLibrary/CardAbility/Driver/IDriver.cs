using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Parameter;
using System;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver
{
    /// <summary>
    /// 技能驱动器基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class IDriver<T> : BaseCardAbility where T : Action.IGameAction
    {
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            Activator.CreateInstance<T>().Action(actionParameter);
            return null;
        }
    }
}
