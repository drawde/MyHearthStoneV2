﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Common.JsonModel
{
    public class IMSingleModelResult<T> : IMResultBase
    {
        public T data { get; set; }
    }
}
