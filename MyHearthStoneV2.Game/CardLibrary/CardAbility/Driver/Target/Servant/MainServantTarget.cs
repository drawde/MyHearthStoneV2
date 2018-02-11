﻿using MyHearthStoneV2.Game.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Target.Servant
{
    internal class MainServantTarget : IServantTarget
    {
        public Func<Card, bool> Filter(BaseActionParameter actionParameter)
        {
            return new Func<Card, bool>(c => c != null && c.CardType == CardType.随从 && c.CardInGameCode == actionParameter.MainCard.CardInGameCode);
        }
    }
}
