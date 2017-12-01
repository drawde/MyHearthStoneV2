using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.Monitor;
using MyHearthStoneV2.CardLibrary.Servant;
using MyHearthStoneV2.CardLibrary.Spell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.Controler
{
    public partial class Controler_Base
    {
        /// <summary>
        /// 打出一张法术牌
        /// </summary>
        /// <param name="spell"></param>
        /// <param name="target"></param>
        [ControlerMonitor, PlayerActionMonitor]
        public void CastSpell(BaseSpell spell, List<int> target)
        {
            #region 触发场内牌的技能
            TriggerCardAbility(GetCurrentTurnUserCards().DeskCards, CardLocation.场上, SpellCardAbilityTime.己方打出法术牌前, spell, target);
            #endregion

            var user = GetCurrentTurnUserCards();
            user.Power -= spell.Cost;
            spell.CardLocation = CardLocation.坟场;

            #region 触发场内牌的技能
            TriggerCardAbility(GetCurrentTurnUserCards().DeskCards, CardLocation.场上, SpellCardAbilityTime.己方打出法术牌后, spell, target);
            #endregion
        }
    }
}
