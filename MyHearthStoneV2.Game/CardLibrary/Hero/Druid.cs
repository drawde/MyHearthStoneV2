using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.HeroPower;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Hero
{
    public class Druid : BaseHero
    {
        public override string Name { get; set; } = "德鲁伊";
        public override Profession Profession { get; set; } = Profession.Druid;
        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new DruidAbility() };
    }
}
