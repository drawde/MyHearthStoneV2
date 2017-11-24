using MyHearthStoneV2.CardLibrary.Context;
using MyHearthStoneV2.CardLibrary.Controler;
using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Log;
using MyHearthStoneV2.Model;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
namespace MyHearthStoneV2.CardLibrary.Monitor
{
    /// <summary>
    /// 控制器监控器（保存游戏控制器对象、封装游戏对象的输出）
    /// </summary>
    [Serializable]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class ControlerMonitor: OnMethodBoundaryAspect
    {
        string _methodName = "";
        string _className = "";
        public override void CompileTimeInitialize(MethodBase method, AspectInfo aspectInfo)
        {
            _className = method.DeclaringType.Name;
            _methodName = method.Name;
        }
        public override void OnException(MethodExecutionArgs args)
        {
            HS_ErrRec ex = new HS_ErrRec();
            ex.Action = _methodName;
            ex.AddTime = DateTime.Now;
            ex.Controller = _className;
            ex.ErrorMsg = args.Exception.Message;
            ex.IP = StringUtil.GetIP();
            ex.StackTrace = args.Exception.StackTrace;
            ex.Arguments = "";
            if (args.Arguments != null && args.Arguments.Count > 0)
            {
                ex.Arguments = args.Arguments.ToJsonString();
            }
            ex.DataSource = (int)DataSourceEnum.GameControler;
            ErrRecBll.Instance.AsyncInsert(ex);
            //args.ReturnValue = JsonModelResult.Package500();
            args.FlowBehavior = FlowBehavior.ThrowException;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            base.OnEntry(args);
        }

        /// <summary>
        /// 游戏控制器方法结束前，封装游戏对象的输出
        /// </summary>
        /// <param name="eventArgs"></param>
        public override void OnExit(MethodExecutionArgs eventArgs)
        {
            if (eventArgs.Arguments != null && eventArgs.Arguments.Count > 0)
            {
                DataExchangeBll.Instance.AsyncInsert(_methodName, _className, eventArgs.Arguments.ToJsonString(), eventArgs.ReturnValue.TryParseString().ToJsonString(), DataSourceEnum.GameControler);
            }
            Controler_Base ctl = eventArgs.Instance as Controler_Base;
            

            #region 封装输出
            ctl.gameContextOutput = new GameContextOutput();
            ctl.gameContextOutput.Players = new List<BaseUserContext>();
            ctl.gameContextOutput.GameCode = ctl.GameCode;
            ctl.gameContextOutput.TurnIndex = ctl.TurnIndex;
            foreach (var cd in ctl.gameContext.Players)
            {
                if (cd.IsActivation)
                {
                    ctl.gameContextOutput.Players.Add(new UserContextOutput()
                    {
                        DeskCards = cd.DeskCards,
                        HandCards = cd.HandCards,
                        InitCards = cd.InitCards,
                        IsActivation = cd.IsActivation,
                        IsFirst = cd.IsFirst,
                        Power = cd.Power,
                        StockCards = cd.StockCards.Count,
                        SwitchDone = cd.SwitchDone,
                        UserCode = cd.UserCode,
                        TurnIndex = ctl.TurnIndex
                    });
                }
                else
                {
                    ctl.gameContextOutput.Players.Add(new UserContextSimpleOutput()
                    {
                        DeskCards = cd.DeskCards,
                        HandCards = cd.HandCards.Count,
                        InitCards = cd.InitCards.Count,
                        IsActivation = cd.IsActivation,
                        IsFirst = cd.IsFirst,
                        Power = cd.Power,
                        StockCards = cd.StockCards.Count,
                        SwitchDone = cd.SwitchDone,
                        UserCode = cd.UserCode,
                        TurnIndex = ctl.TurnIndex
                    });
                }
            }
            #endregion
            ControllerCache.SetController(ctl);
            base.OnEntry(eventArgs);
        }
    }
}
