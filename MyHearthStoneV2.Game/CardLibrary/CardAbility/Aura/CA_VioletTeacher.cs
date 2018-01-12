﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.Spell;
using MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical;
using MyHearthStoneV2.Game.Controler;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Aura
{
    public class CA_VioletTeacher : BaseCardAbility
    {
        public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.己方打出法术牌前 };
        public override void CastAbility(GameContext gameContext, Card triggerCard, Card sourceCard, int targetCardIndex, int location)
        {
            //必须是自己打出的法术类牌才能触发自己的紫罗兰教师的技能
            if (gameContext.IsThisActivationUserCard(triggerCard) && gameContext.IsThisActivationUserCard(sourceCard) && triggerCard is BaseSpell)
            {
                var player = gameContext.GetActivationUserContext();
                if (gameContext.DeskCards.GetDeskCardsByMyCard(sourceCard as BaseBiology).Any(c => c == null))
                {
                    VioletStudent student = gameContext.CreateNewCardInDesk<VioletStudent>();                     
                }
            }
        }
    }
}
