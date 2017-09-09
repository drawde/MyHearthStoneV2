using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardSpecialEffect.WarCry
{
    public class SE_JiaoXiaoDeZhongShi:ISpecialEffect
    {
        public override CardEnum.BuffTimeLimit buffTime { get; } = CardEnum.BuffTimeLimit.无限制;
    }
}
