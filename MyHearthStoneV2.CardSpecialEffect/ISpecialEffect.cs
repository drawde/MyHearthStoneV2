using MyHearthStoneV2.CardEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardSpecialEffect
{
    public abstract class ISpecialEffect
    {
        public virtual BuffTimeLimit buffTime { get; }
    }
}
