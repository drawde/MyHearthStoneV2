using PostSharp.Aspects;
using PostSharp.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.Monitor
{
    /// <summary>
    /// 游戏环境监视器（用于监控游戏环境中的各种变化、事件，然后触发相应的卡牌技能）
    /// </summary>
    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Field)]
    public class GameContextObserver : OnMethodBoundaryAspect
    {
    }
}
