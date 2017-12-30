using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.HeroPower;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Hero
{
    public class Warlock : BaseHero
    {
        public virtual new string Name { get; } = "术士";
        public virtual new Profession Profession { get; } = Profession.Warlock;
        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new DruidAbility() };
    }
}
