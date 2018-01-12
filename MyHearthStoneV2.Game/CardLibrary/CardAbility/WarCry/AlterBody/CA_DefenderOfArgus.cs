using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using System.Collections.Generic;
using MyHearthStoneV2.Game.Controler;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.WarCry.AlterBody
{
    public class CA_DefenderOfArgus: BaseCardAbility
    {
        public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.战吼 };
        public override void CastAbility(GameContext gameContext, Card triggerCard, Card sourceCard, int targetCardIndex, int location)
        {
            if (gameContext.IsThisActivationUserCard(sourceCard))
            {
                var player = gameContext.GetActivationUserContext();
                List<BaseBiology> lstBiologys = gameContext.DeskCards.GetDeskCardsByIsFirst(player.IsFirst);
                if (location > 1)
                {
                    BaseServant left = lstBiologys[location - 1] as BaseServant;
                    left.Abilities.Add(new Taunt());
                    left.Damage += 1;
                    left.Life += 1;
                    //left.Buffs.Add(sourceCard, new CA_DefenderOfArgus());
                    left.Abilities.Add(new REV_DefenderOfArgus());
                }
                if (location < 8)
                {
                    BaseServant right = lstBiologys[location - 1] as BaseServant;
                    right.Abilities.Add(new Taunt());
                    right.Damage += 1;
                    right.Life += 1;
                    //right.Buffs.Add(sourceCard, new CA_DefenderOfArgus());
                    right.Abilities.Add(new REV_DefenderOfArgus());
                }
            }
        }
    }
}
