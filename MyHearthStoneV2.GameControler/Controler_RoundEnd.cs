using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.GameControler
{
    public partial class Controler
    {
        /// <summary>
        /// 回合结束
        /// </summary>
        internal void RoundEnd()
        {
            //if (roundIndex != 2 && !chessboard.Players.Any(c => c.HandCards.Count < 1))
            //{

            //}
            roundIndex++;
            currentRoundRemainingSecond = 60;
        }
    }
}
