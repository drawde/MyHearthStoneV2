using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Pick
{
    internal class RandomPick : IPickType
    {
        PickType IPickType.PickType { get; set; } = PickType.随机;
    }
}
