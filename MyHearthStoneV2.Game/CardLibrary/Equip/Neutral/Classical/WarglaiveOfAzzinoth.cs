using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.Equip.Neutral.Classical
{
    public class WarglaiveOfAzzinoth: BaseEquip
    {
        public override string Name { get; } = "埃辛诺斯战刃";
        public override string BackgroudImage { get; set; } = "W19_a256_D.png";

        public override int Damege { get; set; } = 3;
        public override int Durable { get; set; } = 3;

        public override bool IsDerivative => true;
    }
}
