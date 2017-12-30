using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.HeroPower;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Hero
{
    public class Druid : BaseHero
    {
        public virtual new string Name { get; } = "德鲁伊";
        public virtual new Profession Profession { get; } = Profession.Druid;
        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new DruidAbility() };
    }
}
