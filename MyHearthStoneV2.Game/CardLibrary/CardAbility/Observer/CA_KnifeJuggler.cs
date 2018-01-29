using System.Collections.Generic;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Controler;
using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Servant;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Hero;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Action;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Observer
{
    public class CA_KnifeJuggler : BaseCardAbility
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.触发;
        public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get;  set; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.己方随从入场 };
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            var enemyUserContext = actionParameter.GameContext.GetEnemyUserContextByMyCard(actionParameter.MainCard);
            List<int> rndTargets = new List<int>();
            int startIndex = 0, endIndex = 8;
            if (enemyUserContext.IsFirst == false)
            {
                startIndex = 8;
                endIndex = 16;
            }
            for (int i = startIndex; i < endIndex; i++)
            {
                if (actionParameter.GameContext.DeskCards[i] != null && actionParameter.GameContext.DeskCards[i].Life > 0)
                {
                    rndTargets.Add(actionParameter.GameContext.DeskCards[i].DeskIndex);
                }
            }
            if (rndTargets.Count > 0)
            {
                int tar = RandomUtil.CreateRandomInt(0, rndTargets.Count - 1);
                BaseBiology targetBiology = actionParameter.GameContext.DeskCards[rndTargets[tar]];

                BaseActionParameter para = CardActionFactory.CreateParameter(targetBiology, actionParameter.GameContext, 1, secondaryCard: actionParameter.MainCard);
                CardActionFactory.CreateAction(targetBiology, ActionType.受到伤害).Action(para);
                
            }
            return null;
        }
    }
}
