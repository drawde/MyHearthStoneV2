using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Spell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Warrior
{
    public class Execute : BaseSpell
    {
        public override Rarity Rare { get; set; } = Rarity.普通;

        public override string Name { get; set; } = "斩杀";
        public override int Cost { get; set; } = 1;
        public override int InitialCost { get; set; } = 1;
        public override int BuffCost { get; set; } = 1;
        public override string Describe { get; set; } = "消灭一个受过伤害的敌方随从。";

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new CA_Execute() };

        public override string BackgroudImage { get; set; } = "WoW_Chi_061_D.png";
        public override Profession Profession { get; set; } = Profession.Warrior;
    }
}
