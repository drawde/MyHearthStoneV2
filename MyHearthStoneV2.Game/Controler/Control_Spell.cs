﻿
using MyHearthStoneV2.Game.Monitor;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.CardLibrary.Spell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.Game.CardLibrary;

namespace MyHearthStoneV2.Game.Controler
{
    internal partial class Controler_Base
    {
        /// <summary>
        /// 打出一张法术牌
        /// </summary>
        /// <param name="spell"></param>
        /// <param name="target"></param>
        [ControlerMonitor, PlayerActionMonitor]
        internal void CastSpell(BaseSpell spell, int target)
        {
            var currentUserContext = gameContext.GetActivationUserContext();
            var enenmyUserContext = gameContext.GetNotActivationUserContext();
            gameContext.AddActionStatement(currentUserContext.DeskCards, SpellCardAbilityTime.己方打出法术牌前, spell, target);
            gameContext.AddActionStatement(currentUserContext.HandCards, SpellCardAbilityTime.己方打出法术牌前, spell, target);

            gameContext.AddActionStatement(enenmyUserContext.DeskCards, SpellCardAbilityTime.对方打出法术牌前, spell, target);
            gameContext.AddActionStatement(enenmyUserContext.HandCards, SpellCardAbilityTime.对方打出法术牌前, spell, target);

            gameContext.AddActionStatement(spell, SpellCardAbilityTime.打出一张法术牌, spell, target);

            gameContext.AddActionStatement(currentUserContext.DeskCards, SpellCardAbilityTime.己方打出法术牌后, spell, target);
            gameContext.AddActionStatement(currentUserContext.HandCards, SpellCardAbilityTime.己方打出法术牌后, spell, target);

            gameContext.AddActionStatement(enenmyUserContext.DeskCards, SpellCardAbilityTime.对方打出法术牌后, spell, target);
            gameContext.AddActionStatement(enenmyUserContext.HandCards, SpellCardAbilityTime.对方打出法术牌后, spell, target);

            //#region 触发场内牌的技能
            //gameContext.TriggerCardAbility(gameContext.GetActivationUserContext().DeskCards, CardLocation.场上, SpellCardAbilityTime.己方打出法术牌前, spell, target);
            //#endregion
            //gameContext.CastCardCount++;
            //spell.CastIndex = gameContext.CastCardCount;
            //var user = gameContext.GetActivationUserContext();
            //user.Power -= spell.Cost;
            //Card triggerCard = null;
            //if (target > -1)
            //{
            //    triggerCard = gameContext.GetCardByLocation(target);
            //}
            //if (spell.Abilities.Any(c => c.LstSpellCardAbilityTime.Any(x => x == SpellCardAbilityTime.己方打出法术牌后)))
            //{
            //    foreach (var buff in spell.Abilities.Where(c => c.LstSpellCardAbilityTime.Any(x => x == SpellCardAbilityTime.己方打出法术牌后)))
            //    {
            //        buff.CastAbility(gameContext, triggerCard, spell, target);
            //    }
            //}
            //spell.CardLocation = CardLocation.坟场;
            //user.HandCards.Remove(spell);
            //user.GraveyardCards.Add(spell);

            //#region 触发场内牌的技能
            //gameContext.TriggerCardAbility(gameContext.GetActivationUserContext().DeskCards, CardLocation.场上, SpellCardAbilityTime.己方打出法术牌后, spell, target);
            //#endregion
        }
    }
}
