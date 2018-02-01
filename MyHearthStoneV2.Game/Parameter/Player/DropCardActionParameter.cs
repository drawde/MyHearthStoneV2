using MyHearthStoneV2.Game.Context;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.Parameter.Player
{
    internal class DropCardActionParameter : BaseActionParameter
    {
        internal int DropCount { get; set; }
        internal UserContext UserContext { get; set; }

        internal DropCardType DropCardType { get; set; } = DropCardType.随机;

        /// <summary>
        /// 弃牌方式为指定时，设置为被弃牌的下标
        /// </summary>
        internal List<int> DropCardIndex { get; set; } = new List<int>();
    }
}
