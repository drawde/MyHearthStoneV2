using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.DamageType
{
    internal class PhysicalDamage : IDamageType
    {
        ActionType IDamageType.ActionType { get; set; } = ActionType.受到伤害;
    }
}
