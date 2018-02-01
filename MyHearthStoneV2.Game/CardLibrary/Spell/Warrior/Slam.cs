using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Spell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Warrior
{
    public class Slam : BaseSpell
    {
        public override Rarity Rare { get; set; } = Rarity.普通;

        public override string Name { get; set; } = "猛击";
        public override int Cost { get; set; } = 2;
        public override int BuffCost { get; set; } = 2;
        public override int InitialCost { get; set; } = 2;
        public override string Describe { get; set; } = "对一个随从造成2点伤害，如果它依然存活，则抽一张牌。";

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new CA_Slam() };

        public override string BackgroudImage { get; set; } = "W6_002_D.png";
        public override Profession Profession { get; set; } = Profession.Warrior;
    }
}
