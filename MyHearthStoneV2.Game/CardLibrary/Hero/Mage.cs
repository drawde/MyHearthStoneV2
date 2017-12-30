using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.HeroPower;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Hero
{
    public class Mage : BaseHero
    {
        public virtual new string Name { get; } = "法师";
        public virtual new Profession Profession { get; } = Profession.Mage;
        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new MageAbility() };
    }
}
