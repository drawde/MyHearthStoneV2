using System.Collections.Generic;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Controler;
namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Spell
{
    public class AppendPower : BaseCardAbility
    {
        public override BuffTimeLimit BuffTime { get; } = BuffTimeLimit.己方回合结束;
        public override List<SpellCardAbilityTime> LstSpellCardAbilityTime { get; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.打出一张法术牌 };
        public override void CastAbility(GameContext gameContext, Card triggerCard, Card sourceCard, int targetCardIndex, int location = -1)
        {
            gameContext.GetActivationUserContext().Power += 1;
        }
    }
}
