using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Direction
{
    /// <summary>
    /// 正数
    /// </summary>
    internal class Plus: IDirection
    {
        public int SetQuantity(IQuantity quantity)
        {
            return quantity.Quantity;
        }
    }
}
