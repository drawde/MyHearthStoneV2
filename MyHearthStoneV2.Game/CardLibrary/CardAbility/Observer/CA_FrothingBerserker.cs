using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Context;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Observer
{
    public class CA_FrothingBerserker : BaseCardAbility
    {
        public override AbilityType AbilityType { get; } = AbilityType.触发;
        public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.随从受伤 };
        public override void CastAbility(GameContext gameContext, Card triggerCard, Card sourceCard, int targetCardIndex, int location = -1)
        {
            BaseServant servant = sourceCard as BaseServant;
            servant.Damage += 1;
        }
    }
}
