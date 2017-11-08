using MyHearthStoneV2.BLL;
using MyHearthStoneV2.Common.Enum;
using MyHearthStoneV2.Common.JsonModel;
using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Game;
using MyHearthStoneV2.Model;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.GameControler
{
    /// <summary>
    /// 控制器监控器
    /// </summary>
    [Serializable]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    internal class ControlerMonitor: OnMethodBoundaryAspect
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

        public override void OnExit(MethodExecutionArgs eventArgs)
        {
            if (eventArgs.Arguments != null && eventArgs.Arguments.Count > 0)
            {
                DataExchangeBll.Instance.AsyncInsert(_methodName, _className, eventArgs.Arguments.ToJsonString(), eventArgs.ReturnValue.TryParseString().ToJsonString(), DataSourceEnum.GameControler);
            }
            Controler ctl = eventArgs.Instance as Controler;
            

            #region 封装输出
            ctl.chessboardOutput = new ChessboardOutput();
            ctl.chessboardOutput.Players = new List<BaseUserCards>();
            ctl.chessboardOutput.GameCode = ctl.GameCode;
            foreach (var cd in ctl.chessboard.Players)
            {
                if (cd.IsActivation)
                {
                    ctl.chessboardOutput.Players.Add(new UserCardsOutput()
                    {
                        DeskCards = cd.DeskCards,
                        HandCards = cd.HandCards,
                        InitCards = cd.InitCards,
                        IsActivation = cd.IsActivation,
                        IsFirst = cd.IsFirst,
                        Power = cd.Power,
                        StockCards = cd.StockCards.Count,
                        SwitchDone = cd.SwitchDone
                    });
                }
                else
                {
                    ctl.chessboardOutput.Players.Add(new UserCardsSimpleOutput()
                    {
                        DeskCards = cd.DeskCards,
                        HandCards = cd.HandCards.Count,
                        InitCards = cd.InitCards.Count,
                        IsActivation = cd.IsActivation,
                        IsFirst = cd.IsFirst,
                        Power = cd.Power,
                        StockCards = cd.StockCards.Count,
                        SwitchDone = cd.SwitchDone
                    });
                }
            }
            #endregion
            ControllerCache.SetController(ctl);
            base.OnEntry(eventArgs);
        }
    }
}
