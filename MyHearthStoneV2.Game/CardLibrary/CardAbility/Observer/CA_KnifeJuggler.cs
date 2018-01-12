using System.Collections.Generic;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Controler;
using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Servant;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Hero;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.CardLibrary.Servant;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Observer
{
    public class CA_KnifeJuggler : BaseCardAbility
    {
        public override AbilityType AbilityType { get; } = AbilityType.触发;
        public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.己方随从入场 };
        public override void CastAbility(GameContext gameContext, Card triggerCard, Card sourceCard, int targetCardIndex, int location)
        {
            var enemyUserContext = gameContext.GetEnemyUserContextByMyCard(sourceCard);
            List<int> rndTargets = new List<int>();
            int startIndex = 0, endIndex = 8;
            if (enemyUserContext.IsFirst == false)
            {
                startIndex = 8;
                endIndex = 16;
            }
            for (int i = startIndex; i < endIndex; i++)
            {
                if (gameContext.DeskCards[i] != null && gameContext.DeskCards[i].Life > 0)
                {
                    rndTargets.Add(gameContext.DeskCards[i].DeskIndex);
                }
            }
            if (rndTargets.Count > 0)
            {
                int tar = RandomUtil.CreateRandomInt(0, rndTargets.Count - 1);
                BaseBiology targetBiology = gameContext.DeskCards[rndTargets[tar]];

                if (targetBiology.CardType == CardType.英雄)
                {
                    BaseHero hero = targetBiology as BaseHero;
                    hero.BiologyByDamege(sourceCard, gameContext, 1);
                }
                else
                {
                    BaseServant servant = targetBiology as BaseServant;
                    servant.BiologyByDamege(sourceCard, gameContext, 1);
                }
            }
        }
    }
}
