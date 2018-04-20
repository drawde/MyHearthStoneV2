using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver
{
    public interface IDamageType: IGameCache
    {
        ActionType ActionType { get; set; }
    }
}
