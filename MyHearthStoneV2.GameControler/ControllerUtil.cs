﻿using MyHearthStoneV2.Common.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.GameControler
{
    public partial class Controler
    {
        public void SetCurrentRoundCode()
        {
            currentRoundCode = SignUtil.CreateSign(GameID + roundIndex);
        }
    }
}
