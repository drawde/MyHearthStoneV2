using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using System.Linq;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.WarCry.AlterBody
{
    public class REV_DefenderOfArgus: CA_DefenderOfArgus
    {
        public override void CastAbility(GameContext gameContext, Card triggerCard, Card sourceCard, int targetCardIndex, int location)
        {
            BaseServant card = sourceCard as BaseServant;
            card.Damage -= 1;
            card.Life -= 1;
            if (card.Abilities.Any(c => c is Taunt))
            {
                Taunt taunt = card.Abilities.First(c => c is Taunt) as Taunt;
                card.Abilities.Remove(taunt);
            }
            card.Abilities.Remove(this);
            //if (card.Buffs.Any(c => c.Value is Taunt))
            //{
            //    var buff = card.Buffs.First(c => c.Value is Taunt).Key;
            //    card.Buffs.Remove(buff);
            //}
        }
    }
}
