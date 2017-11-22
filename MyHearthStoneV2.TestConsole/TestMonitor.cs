using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.TestConsole
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class TestMonitor : OnMethodBoundaryAspect
    {
        string _methodName = "";
        string _className = "";
        public override void CompileTimeInitialize(MethodBase method, AspectInfo aspectInfo)
        {
            _className = method.DeclaringType.Name;
            _methodName = method.Name;
        }

        /// <summary>
        /// 签名认证
        /// </summary>
        /// <param name="eventArgs"></param>
        public override void OnExit(MethodExecutionArgs eventArgs)
        {
            Console.WriteLine("1");
            base.OnEntry(eventArgs);
            //eventArgs.Instance.GetType().GetMethod("Save").Invoke(eventArgs.Instance, null);
        }
    }
}
