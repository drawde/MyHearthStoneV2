using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Spell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Warrior
{
    public class BattleRage : BaseSpell
    {
        public override Rarity Rare { get; set; } = Rarity.普通;

        public override string Name { get; set; } = "战斗怒火";
        public override int Cost { get; set; } = 2;
        public override int InitialCost { get; set; } = 2;
        public override string Describe { get; set; } = "每有一个受到伤害的友方角色，便抽一张牌。";

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new CA_BattleRage() };

        public override string BackgroudImage { get; set; } = "WOW_ACT_056_D_1.png";
        public override Profession Profession { get; set; } = Profession.Warrior;
    }
}
