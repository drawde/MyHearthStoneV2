using MyHearthStoneV2.BLL;
using MyHearthStoneV2.Common.Enum;
using MyHearthStoneV2.Common.JsonModel;
using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Log;
using MyHearthStoneV2.Model;
using PostSharp.Aspects;
using System;
using System.Reflection;

namespace MyHearthStoneV2.API.Monitor
{
    /// <summary>
    /// SignalR接口方法的监控管理
    /// </summary>
    [Serializable]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class SignalRMethodAttribute: OnMethodBoundaryAspect
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
            ex.DataSource = (int)DataSourceEnum.SignalR;
            ErrRecBll.Instance.AsyncInsert(ex);
            args.ReturnValue = JsonStringResult.VerifyFail();
            args.FlowBehavior = FlowBehavior.Return;
        }

        public override void OnExit(MethodExecutionArgs eventArgs)
        {
            if (eventArgs.Arguments != null && eventArgs.Arguments.Count > 0)
            {
                DataExchangeBll.Instance.AsyncInsert(_methodName, _className, eventArgs.Arguments.TryParseString().ToJsonString(), eventArgs.ReturnValue.TryParseString().ToJsonString(), DataSourceEnum.SignalR);
            }
            base.OnExit(eventArgs);
        }

        /// <summary>
        /// 签名认证
        /// </summary>
        /// <param name="eventArgs"></param>
        public override void OnEntry(MethodExecutionArgs eventArgs)
        {
            Arguments arguments = eventArgs.Arguments;
            if (!UsersBll.Instance.AuthenticationSign(arguments[0].ToString()))
            {
                throw new Exception(JsonStringResult.Error(OperateResCodeEnum.签名验证失败));
            }
            
            base.OnEntry(eventArgs);
        }
    }
}
