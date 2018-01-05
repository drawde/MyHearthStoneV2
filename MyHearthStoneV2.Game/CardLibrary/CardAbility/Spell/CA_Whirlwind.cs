using System.Collections.Generic;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Controler;
using System.Linq;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Servant;
using MyHearthStoneV2.Game.CardLibrary.Servant;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Spell
{
    public class CA_Whirlwind : BaseCardAbility
    {
        public override BuffTimeLimit BuffTime { get; } = BuffTimeLimit.己方回合结束;
        public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.打出一张法术牌 };
        public override void CastAbility(GameContext gameContext, Card triggerCard, Card sourceCard, int targetCardIndex, int location = -1)
        {
            foreach (var servant in gameContext.DeskCards.Where(c => c.CardType == CardType.随从).OrderBy(c => c.CastIndex))
            {
                BaseServant sv = servant as BaseServant;
                sv.BiologyByDamege(sourceCard, gameContext, 1);
            }
        }
    }
}
