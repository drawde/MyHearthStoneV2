using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.HeroPower;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Hero
{
    public class Rogue : BaseHero
    {
        public override string Name { get; set; } = "盗贼";
        public override Profession Profession { get; set; } = Profession.Rogue;
        public override List<IBaseCardAbility> Abilities { get; set; } = new List<IBaseCardAbility>() { new RogueAbility() };
    }
}
