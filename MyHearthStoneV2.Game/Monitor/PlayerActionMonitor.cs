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
using System.Threading.Tasks;

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

            try
            {
                HS_GameRecord record = new HS_GameRecord
                {
                    AddTime = DateTime.Now,
                    GameContext = JsonConvert.SerializeObject(ctl.gameContext),
                    FirstUserCode = ctl.gameContext.GetActivationUserContext().UserCode,
                    GameCode = ctl.GameCode,
                    IsFirstUserTurn = false,
                    TurnIndex = ctl.TurnIndex,
                    SecondUserCode = ctl.gameContext.GetNotActivationUserContext().UserCode,
                    TurnCode = ctl.currentTurnCode,
                    FunctionName = _methodName
                };
                GameRecordBll.Instance.Insert(record);
            }
            catch (Exception ex)
            {

                throw;
            }

            base.OnEntry(eventArgs);
        }
    }
}
