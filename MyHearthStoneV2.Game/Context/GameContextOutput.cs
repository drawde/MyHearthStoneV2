﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.Context
{
    /// <summary>
    /// 游戏环境上下文（用于输出）
    /// </summary>
    public class GameContextOutput
    {
        public string GameCode { get; set; }

        public int TurnIndex { get; set; }
        /// <summary>
        /// 本局中对战的玩家
        /// </summary>
        public List<BaseUserContext> Players { get; set; }
    }
}
