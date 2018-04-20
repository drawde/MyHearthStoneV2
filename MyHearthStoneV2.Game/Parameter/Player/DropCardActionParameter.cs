using MyHearthStoneV2.Game.Context;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.Parameter.Player
{
    public class DropCardActionParameter : BaseActionParameter
    {
        public int DropCount { get; set; }
        public UserContext UserContext { get; set; }

        public PickType DropCardType { get; set; } = PickType.随机;

        /// <summary>
        /// 弃牌方式为指定时，设置为被弃牌的下标
        /// </summary>
        public List<int> DropCardIndex { get; set; } = new List<int>();
    }
}
