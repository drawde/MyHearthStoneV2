using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Filter
{
    public interface IServantFilter
    {
        Func<BaseServant, bool> Filter(BaseServant baseServant);
    }
}
