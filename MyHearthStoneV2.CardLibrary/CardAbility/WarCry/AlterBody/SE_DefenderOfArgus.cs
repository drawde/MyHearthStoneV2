using MyHearthStoneV2.CardEnum;
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
    public class SE_DefenderOfArgus: BaseSpecialEffect
    {
        public override List<SpellCardAbilityTime> LstSpellCardAbilityTime { get; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.入场 };
        public override void CastAbility(GameContext gameContext, Card triggerCard, Card sourceCard, List<int> targetCardIndex, int location)
        {
            if (gameContext.IsThisActivationUserCard(sourceCard))
            {
                var player = gameContext.GetActivationUserContext();
                if (location > 0)
                {
                    BaseServant left = player.DeskCards[location - 1] as BaseServant;
                    left.LstBuff.Add(new Taunt());
                    left.Damage += 1;
                    left.Life += 1;
                }
                if (location < 7)
                {
                    BaseServant right = player.DeskCards[location - 1] as BaseServant;
                    right.LstBuff.Add(new Taunt());
                    right.Damage += 1;
                    right.Life += 1;
                }
            }
        }
    }
}
