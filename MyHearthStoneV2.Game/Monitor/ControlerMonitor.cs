using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Controler;
using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Log;
using MyHearthStoneV2.Model;
using PostSharp.Aspects;
using System;
using System.Reflection;


namespace MyHearthStoneV2.Game.Monitor
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
            HS_ErrRec ex = new HS_ErrRec
            {
                Action = _methodName,
                AddTime = DateTime.Now,
                Controller = _className,
                ErrorMsg = args.Exception.Message,
                IP = StringUtil.GetIP(),
                StackTrace = args.Exception.StackTrace,
                Arguments = ""
            };
            if (args.Arguments != null && args.Arguments.Count > 0)
            {
                ex.Arguments = args.Arguments.ToJsonString();
            }
            ex.DataSource = (int)DataSourceEnum.GameControler;
            ErrRecBll.Instance.AsyncInsert(ex);
            //args.ReturnValue = JsonModelResult.Package500();
            args.FlowBehavior = FlowBehavior.ThrowException;
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

            #endregion
            GameContextCache.SetContext(ctl.gameContext);
            base.OnEntry(eventArgs);
        }
    }
}
