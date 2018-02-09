using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.Equip.Rogue
{
    public class WickedKnife : BaseEquip
    {
        public override string Name { get; set; } = "邪恶短刀";
        public override string BackgroudImage { get; set; } = "W14_a200_D.png";

        public override int Damage { get; set; } = 1;
        
        public override int InitialDamege { get; set; } = 1;
        public override int Durable { get; set; } = 2;
        public override int Cost { get; set; } = 2;
        public override int InitialCost { get; set; } = 2;
        public override string Describe { get; set; } = "";
        public override bool IsDerivative { get; set; } = true;

        public override Profession Profession { get; set; } = Profession.Rogue;
    }
}
