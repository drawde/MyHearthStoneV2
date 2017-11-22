using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardSpecialEffect.Aura
{
    public class SE_VioletTeacher: BaseSpecialEffect
    {
        public override CardEnum.BuffTimeLimit buffTime { get; } = CardEnum.BuffTimeLimit.无限制;
    }
}
