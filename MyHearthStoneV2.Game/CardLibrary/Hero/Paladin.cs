using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.HeroPower;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Hero
{
    public class Paladin : BaseHero
    {
        public override string Name => "圣骑士";
        public override Profession Profession => Profession.Paladin;
        public override List<ICardAbility> Abilities => new List<ICardAbility>() { new PaladinAbility() };
    }

}
