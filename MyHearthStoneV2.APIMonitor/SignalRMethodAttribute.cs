using MyHearthStoneV2.BLL;
using MyHearthStoneV2.Common.Enum;
using MyHearthStoneV2.Common.JsonModel;
using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.APIMonitor
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
            ErrRecBll.Instance.AsyncInsert(ex);
            args.ReturnValue = JsonStringResult.VerifyFail();
            args.FlowBehavior = FlowBehavior.Return;            
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
