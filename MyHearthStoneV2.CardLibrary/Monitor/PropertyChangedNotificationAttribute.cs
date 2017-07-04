using PostSharp.Aspects;
using PostSharp.Extensibility;
using System;
using System.Reflection;

namespace MyHearthStoneV2.CardLibrary.Monitor
{
    /// <summary>
    /// 卡牌属性监视器
    /// </summary>
    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Method)]
    public class PropertyChangedNotificationAttribute : OnMethodBoundaryAspect
    {
        private object _preValue;

        /// <summary>
        /// 进入函数时输出函数的输入参数
        /// </summary>
        /// <param name="eventArgs"></param>
        public override void OnExit(MethodExecutionArgs eventArgs)
        {
            base.OnExit(eventArgs);
            if (!eventArgs.Method.IsSpecialName) return;
            if (!eventArgs.Method.Name.StartsWith("get_")
                && !eventArgs.Method.Name.StartsWith("set_"))
                return;
            bool isSetter = eventArgs.Method.Name.StartsWith("set_");
            string property = eventArgs.Method.Name.Substring(4);
            if (isSetter)
            {
                var life = 0;
                Console.WriteLine(string.Format("Property \"{0}\" was changed from \"{1}\" to \"{2}\"."
                    , property
                    , this._preValue
                    , this.GetPropertyValue(eventArgs.Instance, property)));
                //Console.WriteLine(eventArgs.Instance);
                if (property == "Life")
                {
                    life = int.Parse(this.GetPropertyValue(eventArgs.Instance, property).ToString());
                    if (life == 0)
                    {
                        var mths = eventArgs.Instance.GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                        foreach (var mth in mths)
                        {

                        }
                        //eventArgs.Instance.GetType().GetMethod("Spell").Invoke(eventArgs.Instance, null);
                    }
                }
            }
            else
            {
                Console.WriteLine(string.Format("Property \"{0}\" was read.", property));
            }
        }

        /// <summary>
        /// 退出函数时的函数返回值
        /// </summary>
        /// <param name="eventArgs"></param>
        public override void OnEntry(MethodExecutionArgs eventArgs)
        {
            base.OnEntry(eventArgs);
            //记录属性更改前的值 
            if (!eventArgs.Method.IsSpecialName) return;
            if (!eventArgs.Method.Name.StartsWith("set_")) return;
            string property = eventArgs.Method.Name.Substring(4);
            this._preValue = this.GetPropertyValue(eventArgs.Instance, property);
        }
        private object GetPropertyValue(object instance, string property)
        {
            PropertyInfo getter = instance.GetType().GetProperty(property);
            return getter.GetValue(instance, null);
        }
    }
}
