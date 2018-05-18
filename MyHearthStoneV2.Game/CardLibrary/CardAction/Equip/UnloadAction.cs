using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.CardAbility;
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
    public class UnloadAction : Action.IGameAction
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            EquipActionParameter para = actionParameter as EquipActionParameter;
            GameContext gameContext = para.GameContext;
            BaseHero baseHero = gameContext.DeskCards.GetHeroByIsFirst(gameContext.GetUserContextByMyCard(para.Equip).IsFirst);

            baseHero.Equip.CardLocation = CardLocation.灵车;
            gameContext.HearseCards.AddLast(baseHero.Equip);

            if (baseHero.Equip.Abilities.Any(c => c is DeathWhisperDriver<IGameAction, ICardLocationFilter>))
            {
                gameContext.AddActionStatement(baseHero.Equip.Abilities.First(), new CardAbilityParameter()
                {
                    GameContext = gameContext,
                    PrimaryCard = baseHero.Equip,
                });
            }
            //UserContext user = gameContext.GetUserContextByMyCard(baseHero);
            //user.GraveyardCards.Add(baseHero.Equip);
            baseHero.Equip = null;

            return null;
        }
    }
}
