using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.Context;
using MyHearthStoneV2.CardLibrary.Servant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.CardAbility.WarCry.AlterBody
{
    public class REV_JiaoXiaoDeZhongShi : CA_JiaoXiaoDeZhongShi
    {
        public override void CastAbility(GameContext gameContext, Card triggerCard, Card sourceCard, int targetCardIndex, int location)
        {
            BaseServant card = sourceCard as BaseServant;
            card.Damage -= 2;
            card.Buffs.Remove(card.Buffs.First(c => c.Value is CA_JiaoXiaoDeZhongShi).Key);
        }
    }
}