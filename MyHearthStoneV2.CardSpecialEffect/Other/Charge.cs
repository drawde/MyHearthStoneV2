using MyHearthStoneV2.CardSpecialEffect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardSpecialEffect.Other
{
    /// <summary>
    /// 冲锋
    /// </summary>
    public class Charge: ISpecialEffect
    {
        public CardEnum.BuffTimeLimit buffTime = CardEnum.BuffTimeLimit.无限制;
    }
}
