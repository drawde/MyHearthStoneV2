﻿using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.CardAbility;
using MyHearthStoneV2.Game.Parameter.Servant;
using System.Collections.Generic;
using System.Linq;

namespace MyHearthStoneV2.Game.CardLibrary.CardAction.Servant
{
    /// <summary>
    /// 重置随从攻击次数
    /// </summary>
    internal class ResetServantRemainAttackTimes : IGameAction
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            ServantActionParameter para = actionParameter as ServantActionParameter;
            BaseServant servant = para.Biology;
            GameContext gameContext = para.GameContext;
            BaseBiology attackCard = para.SecondaryCard as BaseBiology;

            if (servant.Damage > 0 && servant.CanAttack && servant.RemainAttackTimes < 1 && 
                servant.Abilities.Any(c => c.SpellCardAbilityTimes.Any(x => x == SpellCardAbilityTime.重置攻击次数)) == false)
            {
                servant.RemainAttackTimes += 1;
            }
            else
            {
                gameContext.TriggerCardAbility(new List<Card>() { servant }, SpellCardAbilityTime.重置攻击次数);
            }

            return null;
        }
    }
}
