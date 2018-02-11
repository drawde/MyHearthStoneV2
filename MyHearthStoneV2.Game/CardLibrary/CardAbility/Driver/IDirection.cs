using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver
{
    internal interface IDirection : IGameCache
    {
        int SetQuantity(IQuantity quantity);
    }
}
