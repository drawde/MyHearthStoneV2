
using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.CardLibrary.Context;
using MyHearthStoneV2.CardLibrary.Servant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.CardLibrary.Controler;
namespace MyHearthStoneV2.CardLibrary.CardAbility.WarCry.AlterBody
{
    public class CA_DefenderOfArgus: BaseCardAbility
    {
        public override List<SpellCardAbilityTime> LstSpellCardAbilityTime { get; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.战吼 };
        public override void CastAbility(GameContext gameContext, Card triggerCard, Card sourceCard, int targetCardIndex, int location)
        {
            if (gameContext.IsThisActivationUserCard(sourceCard))
            {
                var player = gameContext.GetActivationUserContext();
                if (location > 1)
                {
                    BaseServant left = player.DeskCards[location - 1] as BaseServant;
                    left.Abilities.Add(new Taunt());
                    left.Damage += 1;
                    left.Life += 1;
                    left.Buffs.Add(sourceCard, new CA_DefenderOfArgus());
                }
                if (location < 8)
                {
                    BaseServant right = player.DeskCards[location - 1] as BaseServant;
                    right.Abilities.Add(new Taunt());
                    right.Damage += 1;
                    right.Life += 1;
                    right.Buffs.Add(sourceCard, new CA_DefenderOfArgus());
                }
            }
        }
    }
}
