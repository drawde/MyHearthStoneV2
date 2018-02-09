using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Quantity
{
    internal class Five : IQuantity
    {
        int IQuantity.Quantity { get; set; } = 5;
    }
}
