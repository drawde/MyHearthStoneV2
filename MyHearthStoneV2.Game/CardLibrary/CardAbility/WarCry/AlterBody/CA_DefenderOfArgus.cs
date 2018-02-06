using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using System.Collections.Generic;
using MyHearthStoneV2.Game.Controler;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.CardAbility;
using MyHearthStoneV2.Game.Action;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.WarCry.AlterBody
{
    public class CA_DefenderOfArgus: BaseCardAbility
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.战吼;
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            CardAbilityParameter abilityPara = actionParameter as CardAbilityParameter;
            BaseServant servant = abilityPara.MainCard as BaseServant;
            if (abilityPara.GameContext.IsThisActivationUserCard(abilityPara.MainCard))
            {
                var player = abilityPara.GameContext.GetUserContextByMyCard(actionParameter.MainCard);
                //List<BaseBiology> lstBiologys = abilityPara.GameContext.DeskCards.GetDeskCardsByIsFirst(player.IsFirst);
                int mainCardLocation = servant.DeskIndex;
                if (mainCardLocation != 1 && mainCardLocation != 8)
                {
                    BaseBiology left = abilityPara.GameContext.DeskCards[abilityPara.MainCardLocation - 1] as BaseServant;
                    if (left != null && left.CardType != CardType.英雄)
                    {
                        left.Abilities.Add(new Taunt());
                        left.Damage += 1;
                        left.Life += 1;
                        left.BuffLife += 1;
                        left.Abilities.Add(new REV_DefenderOfArgus());
                        BaseActionParameter para = CardActionFactory.CreateParameter(left, actionParameter.GameContext);
                        CardActionFactory.CreateAction(left, ActionType.重置攻击次数).Action(para);
                    }
                    
                }
                if (mainCardLocation != 7 && mainCardLocation != 15)
                {
                    BaseBiology right = abilityPara.GameContext.DeskCards[abilityPara.MainCardLocation + 1] as BaseServant;
                    if (right != null && right.CardType != CardType.英雄)
                    {
                        right.Abilities.Add(new Taunt());
                        right.Damage += 1;
                        right.Life += 1;
                        right.BuffLife += 1;
                        right.Abilities.Add(new REV_DefenderOfArgus());
                        BaseActionParameter para = CardActionFactory.CreateParameter(right, actionParameter.GameContext);
                        CardActionFactory.CreateAction(right, ActionType.重置攻击次数).Action(para);
                    }
                }
            }
            return null;
        }
    }
}
