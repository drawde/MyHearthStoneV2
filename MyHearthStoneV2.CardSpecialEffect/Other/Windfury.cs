using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardSpecialEffect.Other
{
    /// <summary>
    /// 风怒
    /// </summary>
    public class Windfury : BaseSpecialEffect
    {
        public override CardEnum.BuffTimeLimit buffTime { get; } = CardEnum.BuffTimeLimit.无限制;
    }
}
