using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.Monitor;
using System.Linq;
using MyHearthStoneV2.Game.CardLibrary.CardAction;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Hero;
using MyHearthStoneV2.Game.CardLibrary.Equip;
using MyHearthStoneV2.Game.Parameter.CardAbility;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Parameter.Equip;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Equip;

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
            CardAbilityParameter para = new CardAbilityParameter()
            {
                GameContext = GameContext,
                MainCard = hero,                
            };
            if (target > -1)
            {
                para.SecondaryCard = GameContext.DeskCards[target];
            }
            hero.Abilities.First().Action(para);
            UserContext user = GameContext.GetUserContextByMyCard(hero);
            user.RemainingHeroPowerCastCount -= 1;
            user.Power -= hero.HeroPowerCost < 0 ? 0 : hero.HeroPowerCost;
        }

        /// <summary>
        /// 英雄攻击进行阶段
        /// </summary>
        /// <param name="servant"></param>
        /// <param name="target"></param>
        [ControlerMonitor(AttributePriority = 99), PlayerActionMonitor(AttributePriority = 98), UserActionMonitor(AttributePriority = 1)]
        internal void HeroAttack(BaseHero hero, int target)
        {
            BaseActionParameter para = CardActionFactory.CreateParameter(hero, GameContext, secondaryCard: GameContext.DeskCards[target]);
            CardActionFactory.CreateAction(hero, ActionType.攻击).Action(para);
            //hero.Attack(GameContext, GameContext.DeskCards[target]);
        }


        [ControlerMonitor(AttributePriority = 99), PlayerActionMonitor(AttributePriority = 98), UserActionMonitor(AttributePriority = 1)]
        internal void LoadEquip(BaseHero hero, BaseEquip equip)
        {
            var user = GameContext.GetUserContextByMyCard(hero);
            user.Power -= equip.Cost < 0 ? 0 : equip.Cost;
            EquipActionParameter equipPara = new EquipActionParameter()
            {
                GameContext = GameContext,
                Equip = equip,
                Hero = hero,
            };
            new LoadAction().Action(equipPara);
            //hero.LoadEquip(GameContext, equip);
        }
    }
}
