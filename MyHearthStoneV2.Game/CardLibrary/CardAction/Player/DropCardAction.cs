using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.CardAction.Player
{
    /// <summary>
    /// 弃牌
    /// </summary>
    public class DropCardAction : Action.IGameAction
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            DropCardActionParameter dropPara = actionParameter as DropCardActionParameter;
            int dropCount = dropPara.DropCount;
            UserContext uc = dropPara.UserContext;
            
            
            if (dropPara.DropCardType == PickType.随机 && uc.HandCards.Count > 0)
            {
                List<int> dropList = new List<int>();
                for (int i = 0; i < uc.HandCards.Count; i++)
                {
                    dropList.Add(i);
                }
                if (dropList.Count < dropCount)
                {
                    dropCount = dropList.Count;
                }
                List<int> dropIdx = RandomUtil.CreateRandomInt(0, dropList.Count - 1, dropCount).OrderByDescending(c => c).ToList();
                foreach (int idx in dropIdx)
                {
                    Card card = uc.HandCards[idx];
                    card.CardLocation = CardLocation.坟场;
                    uc.HandCards.RemoveAt(idx);
                    uc.GraveyardCards.Add(card);
                }
            }
                
            
            return null;
        }
    }
}
