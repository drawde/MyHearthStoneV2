using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Spell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Warlock
{
    public class PowerOverwhelming : BaseSpell
    {
        public override Rarity Rare { get; set; } = Rarity.普通;

        public override string Name { get; set; } = "力量的代价";
        public override int Cost { get; set; } = 1;
        public override int InitialCost { get; set; } = 1;
        public override string Describe { get; set; } = "直到回合结束，使一个友方随从获得+4/+4，然后将其消灭。";

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new CA_PowerOverwhelming() };

        public override string BackgroudImage { get; set; } = "Classical/PowerOverwhelming.jpg";
        public override Profession Profession { get; set; } = Profession.Warlock;
    }
}
