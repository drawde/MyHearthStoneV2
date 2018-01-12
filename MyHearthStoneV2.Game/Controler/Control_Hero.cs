using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.Monitor;
using System.Linq;
using MyHearthStoneV2.Game.CardLibrary.CardAction;
namespace MyHearthStoneV2.Game.Controler
{
    internal partial class Controler_Base
    {
        /// <summary>
        /// 使用英雄技能
        /// </summary>
        /// <param name="servant"></param>
        /// <param name="target"></param>
        [ControlerMonitor(AttributePriority = 99), PlayerActionMonitor(AttributePriority = 98), UserActionMonitor(AttributePriority = 1)]
        internal void CastHeroPower(BaseHero hero, int target = -1)
        {
            hero.Abilities.First().CastAbility(GameContext, null, hero, target);
        }

        /// <summary>
        /// 英雄攻击进行阶段
        /// </summary>
        /// <param name="servant"></param>
        /// <param name="target"></param>
        [ControlerMonitor(AttributePriority = 99), PlayerActionMonitor(AttributePriority = 98), UserActionMonitor(AttributePriority = 1)]
        internal void HeroAttack(BaseHero hero, int target)
        {
            hero.Attack(GameContext, GameContext.DeskCards[target]);
        }
    }
}
