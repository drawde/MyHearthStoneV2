using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.CardLibrary.Context;
using MyHearthStoneV2.CardLibrary.Servant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.CardAbility.WarCry.AlterBody
{
    public class REV_DefenderOfArgus: CA_DefenderOfArgus
    {
        public override void CastAbility(GameContext gameContext, Card triggerCard, Card sourceCard, int targetCardIndex, int location)
        {
            BaseServant card = sourceCard as BaseServant;
            card.Damage -= 1;
            card.Life -= 1;
            if (card.Buffs.Any(c => c.Value is Taunt))
            {
                var buff = card.Buffs.First(c => c.Value is Taunt).Key;
                card.Buffs.Remove(buff);
            }
        }
    }
}
