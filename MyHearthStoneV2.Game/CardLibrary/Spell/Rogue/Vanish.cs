using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Servant;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Spell;
using MyHearthStoneV2.Game.CardLibrary.Spell;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Rogue
{
    public class Vanish : BaseSpell
    {
        public override Rarity Rare { get; set; } = Rarity.普通;

        public override string Name { get; set; } = "消失";
        public override int Cost { get; set; } = 6;
        public override int InitialCost { get; set; } = 6;
        public override string Describe { get; set; } = "将所有随从移回其拥有者的手牌。";

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>()
        {
            new SpellDriver<Recover<AllServantFilter>>(),
            //new CA_Vanish()
        };

        public override string BackgroudImage { get; set; } = "Classical/Vanish.jpg";
        public override Profession Profession { get; set; } = Profession.Rogue;
    }
}
