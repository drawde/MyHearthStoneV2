using MyHearthStoneV2.CardEnum;
using MyHearthStoneV2.CardLibrary.Context;
using MyHearthStoneV2.CardLibrary.Monitor;
using MyHearthStoneV2.CardLibrary.Servant;
using System.Linq;
using System.Collections.Generic;
using MyHearthStoneV2.CardLibrary.Base;

namespace MyHearthStoneV2.CardLibrary.Controler
{
    public partial class Controler_Base
    {
        /// <summary>
        /// 将一名随从从手牌中移到场上
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="cardInGameCode"></param>
        /// <param name="location"></param>
        [ControlerMonitor, PlayerActionMonitor]
        public void CastServant(UserContext user, BaseServant card, int location, List<int> target)
        {
            #region 首先触发打出的这张牌的技能
            if (card.LstBuff.Any(c => c.LstSpellCardAbilityTime.Any(x => x == SpellCardAbilityTime.入场)))
            {
                foreach (var buff in card.LstBuff.Where(c => c.LstSpellCardAbilityTime.Any(x => x == SpellCardAbilityTime.入场)))
                {
                    buff.CastAbility(gameContext, card, card, target, location);
                }
            }
            #endregion

            user.Power -= card.Cost;
            card.CardLocation = CardLocation.场上;
            user.DeskCards[location] = card;

            #region 然后触发场内牌的技能
            var lstAllDeskCard = gameContext.AllCard.Where(c => c.CardLocation == CardLocation.场上);
            foreach (Card cd in lstAllDeskCard)
            {
                BaseServant servant = cd as BaseServant;
                if (servant.LstBuff.Any(c => c.LstSpellCardAbilityTime.Any(x => x == SpellCardAbilityTime.入场)))
                {
                    foreach (var buff in servant.LstBuff.Where(c => c.LstSpellCardAbilityTime.Any(x => x == SpellCardAbilityTime.入场)))
                    {
                        buff.CastAbility(gameContext, card, cd, target, location);
                    }
                }
            }
            #endregion

            
        }
    }
}
