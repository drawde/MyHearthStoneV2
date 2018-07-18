using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.HeroPower;
using System.Collections.Generic;

namespace BattleForAzeroth.Game.CardLibrary.Hero
{
    public class Paladin : BaseHero
    {
        public override string Name => "圣骑士";
        public override Profession Profession => Profession.Paladin;
        public override List<ICardAbility> Abilities => new List<ICardAbility>() { new PaladinAbility() };
    }

}
