﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHearthStoneV2.API.Hubs.ChosenCardGroup
{
    interface IChosenCardGroupHub: IHub
    {        
        string IAmReady(string param);
    }
}