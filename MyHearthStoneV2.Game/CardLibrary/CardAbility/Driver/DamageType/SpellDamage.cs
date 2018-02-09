using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.DamageType
{
    internal class SpellDamage :IDamageType
    {
        ActionType IDamageType.ActionType { get; set; } = ActionType.受到法术伤害;
    }
}
