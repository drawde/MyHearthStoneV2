﻿using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.CardAbility;
using MyHearthStoneV2.Game.Parameter.Hero;
using System.Linq;

namespace MyHearthStoneV2.Game.CardLibrary.CardAction.Hero
{
    /// <summary>
    /// 被攻击
    /// </summary>
    public class HeroUnderAttackAction : Action.IGameAction
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            HeroActionParameter para = actionParameter as HeroActionParameter;
            BaseHero baseHero = para.Biology;
            GameContext gameContext = para.GameContext;
            BaseBiology attackCard = para.SecondaryCard as BaseBiology;
            int trueDamege = attackCard.Damage;
            if (attackCard.CardType == CardType.英雄)
            {
                BaseHero attackHero = attackCard as BaseHero;
                if (attackHero.Equip != null)
                {
                    trueDamege += attackHero.Equip.Damage;
                }
            }
            BaseActionParameter underAttackPara = CardActionFactory.CreateParameter(baseHero, actionParameter.GameContext, trueDamege, secondaryCard: attackCard);
            CardActionFactory.CreateAction(baseHero, ActionType.受到伤害).Action(underAttackPara);
            return null;
        }
    }
}
