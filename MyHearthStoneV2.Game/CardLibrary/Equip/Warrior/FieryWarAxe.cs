using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.Equip.Warrior
{
    public class FieryWarAxe : BaseEquip
    {
        public override string Name { get; set; } = "炽炎战斧";
        public override string BackgroudImage { get; set; } = "W14_a200_D.png";

        public override int Damage { get; set; } = 3;

        public override int BuffDamage { get; set; } = 3;
        public override int InitialDamege { get; set; } = 3;
        public override int Durable { get; set; } = 2;
        public override int Cost { get; set; } = 2;
        public override int BuffCost { get; set; } = 2;
        public override int InitialCost { get; set; } = 2;
        public override string Describe { get; set; } = "";

        public override Profession Profession { get; set; } = Profession.Warrior;
    }
}
