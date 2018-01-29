using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.Equip;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Equip;
using MyHearthStoneV2.Game.Parameter.Hero;
using System;
using System.Collections.Generic;
using System.Linq;
namespace MyHearthStoneV2.Game.CardLibrary.CardAction.Equip
{
    internal class LoadAction : IGameAction
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            EquipActionParameter para = actionParameter as EquipActionParameter;
            BaseHero baseHero = para.Hero;
            GameContext gameContext = para.GameContext;
            BaseEquip equip = para.Equip;

            if (baseHero.Equip != null)
            {
                var oldEquip = baseHero.Equip;
                oldEquip.CardLocation = CardLocation.坟场;
                if (oldEquip.Abilities.Any(c => c.AbilityType == AbilityType.亡语))
                    gameContext.TriggerCardAbility(new List<Card> { equip }, SpellCardAbilityTime.无, equip);
            }
            baseHero.Equip = equip;

            var user = gameContext.GetUserContextByMyCard(equip);
            gameContext.CastCardCount++;
            equip.CastIndex = gameContext.CastCardCount;
            equip.CardLocation = CardLocation.场上;
            if (user.HandCards.Any(c => c.CardInGameCode == equip.CardInGameCode))
                user.HandCards.RemoveAt(user.HandCards.FindIndex(c => c.CardInGameCode == equip.CardInGameCode));
            else if (user.StockCards.Any(c => c.CardInGameCode == equip.CardInGameCode))
                user.StockCards.RemoveAt(user.HandCards.FindIndex(c => c.CardInGameCode == equip.CardInGameCode));

            BaseActionParameter resetPara = CardActionFactory.CreateParameter(baseHero, actionParameter.GameContext);
            CardActionFactory.CreateAction(baseHero, ActionType.重置攻击次数).Action(resetPara);

            //baseHero.ResetRemainAttackTimes(gameContext);
            return null;
        }
    }
}
