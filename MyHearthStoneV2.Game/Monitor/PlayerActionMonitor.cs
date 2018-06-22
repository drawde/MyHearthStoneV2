using MyHearthStoneV2.Game.Controler;
using MyHearthStoneV2.Log;
using MyHearthStoneV2.Model;
using Newtonsoft.Json;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using MyHearthStoneV2.Game.Context;

namespace MyHearthStoneV2.Game.Monitor
{
    /// <summary>
    /// 玩家操作监控器，把操作结果存进HS_GameRecord表
    /// </summary>
    [Serializable]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class PlayerActionMonitor : OnMethodBoundaryAspect
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

            HS_GameRecord record = new HS_GameRecord
            {
                AddTime = DateTime.Now,
                //GameContext = JsonConvert.SerializeObject(ctl.GameContext),
                GameContext = "",
                FirstUserCode = ctl.GameContext.GetActivationUserContext().UserCode,
                GameCode = ctl.GameContext.GameCode,
                IsFirstUserTurn = false,
                TurnIndex = ctl.GameContext.TurnIndex,
                SecondUserCode = ctl.GameContext.GetNotActivationUserContext().UserCode,
                TurnCode = ctl.GameContext.CurrentTurnCode,
                FunctionName = _methodName
            };
            GameRecordBll.Instance.Insert(record);

            base.OnEntry(eventArgs);
        }
    }
}
