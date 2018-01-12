using MyHearthStoneV2.Game.Controler;
using PostSharp.Aspects;
using System;
using System.Linq;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary;
using System.Collections.Generic;
using MyHearthStoneV2.Game.CardLibrary.CardAction;
namespace MyHearthStoneV2.Game.Monitor
{
    /// <summary>
    /// 用户行为检测（在用户的一次行为如打出一张牌、随从攻击等行为后，检测游戏环境中的某些变化，如随从死亡，光环更新）
    /// </summary>
    [Serializable]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class UserActionMonitor : OnMethodBoundaryAspect
    {
        public override void OnExit(MethodExecutionArgs eventArgs)
        {
            Controler_Base ctl = eventArgs.Instance as Controler_Base;
            
            //进行死亡检测
            if (ctl.GameContext.DeskCards.Any(c => c != null && c.Life < 1))
            {
                //先按入场顺序排列
                var lstBiology = ctl.GameContext.DeskCards.Where(c => c != null && c.Life < 1).OrderBy(x => x.CastIndex);
                foreach (var bio in lstBiology)
                {
                    bio.BiologyDead(ctl.GameContext, null);
                    //ctl.gameContext.TriggerCardAbility(new List<Card>() { bio }, SpellCardAbilityTime.己方随从入坟场);                    
                }
            }

            GameContextCache.SetContext(ctl.GameContext);
            base.OnEntry(eventArgs);
        }

    }
}
