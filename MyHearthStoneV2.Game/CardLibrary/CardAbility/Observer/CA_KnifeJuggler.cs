using System.Collections.Generic;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Controler;
using MyHearthStoneV2.Common.Util;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Observer
{
    public class CA_KnifeJuggler : BaseCardAbility
    {
        public override AbilityType AbilityType { get; } = AbilityType.触发;
        public override List<SpellCardAbilityTime> LstSpellCardAbilityTime { get; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.己方随从入场 };
        public override void CastAbility(GameContext gameContext, Card triggerCard, Card sourceCard, int targetCardIndex, int location)
        {
            var enemyUserContext = gameContext.GetEnemyUserContextByMyCard(sourceCard);
            List<int> rndTargets = new List<int>();
            for (int i = 0; i < enemyUserContext.DeskCards.Count; i++)
            {
                if (enemyUserContext.DeskCards[i] != null)
                {
                    rndTargets.Add(((BaseBiology)enemyUserContext.DeskCards[i]).DeskIndex);
                }
            }
            if (rndTargets.Count > 0)
            {
                List<int> rnds = RandomUtil.CreateRandomInt(0, rndTargets.Count - 1, rndTargets.Count);
                foreach (int tar in rnds)
                {
                    gameContext.BiologyByDamege(sourceCard, 1, rndTargets[tar]);
                }
            }
        }
    }
}
