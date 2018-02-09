using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver
{
    /// <summary>
    /// 数量
    /// </summary>
    internal interface IQuantity: IGameCache
    {
        int Quantity { get; set; }
    }
}
