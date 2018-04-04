using MyHearthStoneV2.Game.Controler;
using PostSharp.Aspects;
using System;
using System.Linq;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Common.Util;
using System.Collections.Generic;
using MyHearthStoneV2.Game.CardLibrary.CardAction;
using MyHearthStoneV2.Log;
using System.Reflection;
using MyHearthStoneV2.Model;

namespace MyHearthStoneV2.Game.Monitor
{
    /// <summary>
    /// 用户行为检测（在用户的一次行为如打出一张牌、随从攻击等行为后，检测游戏环境中的某些变化，如随从死亡，光环更新）
    /// </summary>
    [Serializable]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class UserActionMonitor : OnMethodBoundaryAspect
    {
        string _methodName = "";
        string _className = "";
        public override void CompileTimeInitialize(MethodBase method, AspectInfo aspectInfo)
        {
            _className = method.DeclaringType.Name;
            _methodName = method.Name;
        }



        public override void OnExit(MethodExecutionArgs eventArgs)
        {
            Controler_Base ctl = eventArgs.Instance as Controler_Base;
            ctl.GameContext.EventQueueSettlement();
            ctl.GameContext.QueueSettlement();

            if (eventArgs.Arguments != null && eventArgs.Arguments.Count > 0)
            {
                DataExchangeBll.Instance.AsyncInsert(_methodName, _className, eventArgs.Arguments.ToJsonString(), eventArgs.ReturnValue.TryParseString().ToJsonString(), DataSourceEnum.GameControler);
            }
            GameContextCache.SetContext(ctl.GameContext);
            base.OnEntry(eventArgs);
        }

    }
}
