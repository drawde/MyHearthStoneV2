using BattleForAzeroth.Game.Util;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Parameter;
using System.Collections.Generic;
using System.Linq;

namespace BattleForAzeroth.Game.CardLibrary.CardAction.Player
{
    /// <summary>
    /// 弃牌
    /// </summary>
    public class DropCardAction : Action.IGameAction
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            int dropCount = actionParameter.DropCount;
            UserContext uc = actionParameter.UserContext;
            
            
            if (actionParameter.DropCardType == PickType.随机 && uc.HandCards.Count() > 0)
            {
                List<int> dropList = new List<int>();
                for (int i = 0; i < uc.HandCards.Count(); i++)
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
                    Card card = uc.HandCards.ToList()[idx];
                    card.CardLocation = CardLocation.坟场;
                }
            }
                
            
            return null;
        }
    }
}
