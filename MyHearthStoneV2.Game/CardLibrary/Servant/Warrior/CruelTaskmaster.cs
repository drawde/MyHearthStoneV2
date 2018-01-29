using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.WarCry.AlterBody;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Warrior
{
    public class CruelTaskmaster : BaseServant
    {
        public override int Damage { get; set; } = 2;
        public override int Life { get; set; } = 2;
        public override int Cost { get; set; } = 2;

        public override int InitialDamage { get; set; } = 2;
        public override int InitialLife { get; set; } = 2;
        public override int InitialCost { get; set; } = 2;


        public override int BuffDamage { get; set; } = 2;
        public override int BuffLife { get; set; } = 2;
        public override int BuffCost { get; set; } = 2;
        public override string Describe
        {
            get
            {
                return "战吼：对一个随从造成1点伤害，并使其获得 2攻击力。";
            }
        }

        public override Rarity Rare
        {
            get
            {
                return Rarity.普通;
            }
        }

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new CA_CruelTaskmaster() };


        public override string Name { get; set; } = "严酷的监工";
        public override string BackgroudImage { get; set; } = "W6_196_D.png";

        public override Profession Profession { get; set; } = Profession.Warrior;
    }
}
