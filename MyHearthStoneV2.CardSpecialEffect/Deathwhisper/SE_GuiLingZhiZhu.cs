﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardSpecialEffect.Deathwhisper
{
    public class SE_GuiLingZhiZhu : ISpecialEffect
    {
        public override CardEnum.BuffTimeLimit buffTime { get;} = CardEnum.BuffTimeLimit.无限制;
    }
}
