using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.Context;
using MyHearthStoneV2.CardLibrary.Controler;
namespace MyHearthStoneV2.CardLibrary.CardAbility.Spell
{
    public class AppendPower : BaseCardAbility
    {
        public override BuffTimeLimit BuffTime { get; } = BuffTimeLimit.己方回合结束;
        public override List<SpellCardAbilityTime> LstSpellCardAbilityTime { get; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.己方打出法术牌后 };
        public override void CastAbility(GameContext gameContext, Card triggerCard, Card sourceCard, int targetCardIndex, int location = -1)
        {
            gameContext.GetActivationUserContext().Power += 1;
        }
    }
}
