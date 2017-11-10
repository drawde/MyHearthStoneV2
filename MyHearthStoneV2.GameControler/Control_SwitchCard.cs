using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.CardEnum;
namespace MyHearthStoneV2.GameControler
{
    internal partial class Controler
    {
        /// <summary>
        /// 开局换牌
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="lstInitCardIndex"></param>
        [ControlerMonitor]
        internal void SwitchCard(string userCode, List<int> lstInitCardIndex)
        {
            nextRoundCode = BLL.ShortCodeBll.Instance.CreateCode(Model.ShortCodeTypeEnum.GameRoundCode);
            UserCards uc = null;
            if (lstInitCardIndex != null && lstInitCardIndex.Count > 0)
            {
                int rndIndex = -1;
                foreach (int i in lstInitCardIndex)
                {
                    uc = chessboard.Players.First(c => c.User.UserCode == userCode);

                    //确保不会换到同一张牌
                    int ri = -1;
                    while (rndIndex == ri)
                    {
                        rndIndex = RandomUtil.CreateRandomInt(0, uc.AllCards.Count - 1);
                    }
                    uc.InitCards[i] = uc.AllCards[rndIndex];
                    ri = rndIndex;
                }
                uc.HandCards = uc.InitCards;
                uc.HandCards.ForEach(c => { c.CardLocation = CardLocation.手牌; });
                //uc.SwitchDone = true;
            }
            if (chessboard.Players.First(c => c.User.UserCode != userCode).SwitchDone)
            {
                RoundEnd();
            }
        }
    }
}
