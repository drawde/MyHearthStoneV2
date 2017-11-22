using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.TestConsole
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class TestMonitorTwo : OnMethodBoundaryAspect
    {
        public override void OnExit(MethodExecutionArgs eventArgs)
        {
            Console.WriteLine("2");
            base.OnEntry(eventArgs);
            //eventArgs.Instance.GetType().GetMethod("Save").Invoke(eventArgs.Instance, null);
        }
    }
}
