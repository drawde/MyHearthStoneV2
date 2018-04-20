using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Quantity
{
    public class Two : IQuantity
    {
        int IQuantity.Quantity { get; set; } = 2;
    }
}
