using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Equip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.CardAction.Equip
{
    /// <summary>
    /// 拆卸装备，如果装备耐久小于1的话
    /// </summary>
    internal class UnloadAction : Action.IGameAction
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            EquipActionParameter para = actionParameter as EquipActionParameter;
            GameContext gameContext = para.GameContext;
            BaseHero baseHero = gameContext.DeskCards.GetHeroByIsFirst(gameContext.GetUserContextByMyCard(para.Equip).IsFirst);

            baseHero.Equip.Durable -= 1;
            if (baseHero.Equip.Durable == 0)
            {
                baseHero.Equip.CardLocation = CardLocation.坟场;
                if (baseHero.Equip.Abilities.Any(c => c.AbilityType == AbilityType.亡语))
                {
                    gameContext.TriggerCardAbility(new List<Card> { baseHero.Equip }, AbilityType.亡语);
                }
                UserContext user = gameContext.GetUserContextByMyCard(baseHero);
                user.GraveyardCards.Add(baseHero.Equip);
                baseHero.Equip = null;
            }

            return null;
        }
    }
}
