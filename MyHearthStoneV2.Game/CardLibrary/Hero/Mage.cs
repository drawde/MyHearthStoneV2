using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.HeroPower;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Hero
{
    public class Mage : BaseHero
    {
        public override string Name { get; set; } = "法师";
        public override Profession Profession { get; set; } = Profession.Mage;
        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new MageAbility() };
    }
}
