using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.HeroPower;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Hero
{
    public class Warrior : BaseHero
    {
        public override string Name => "战士";
        public override Profession Profession => Profession.Warrior;
        public override List<ICardAbility> Abilities => new List<ICardAbility>() { new WarriorAbility() };
    }
}
