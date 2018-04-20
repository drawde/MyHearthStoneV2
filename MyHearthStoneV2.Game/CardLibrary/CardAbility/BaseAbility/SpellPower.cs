using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    public class SpellPower : IBaseCardAbility
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.法术强度;
        public int Damage { get; set; } = 1;
    }
}
