using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class Whelp : BaseServant
    {
        public override int Damage { get; set; } = 1;
        public override int Life { get; set; } = 1;
        public override int Cost { get; set; } = 1;

        public override int InitialDamage { get; set; } = 1;
        public override int InitialLife { get; set; } = 1;
        public override int InitialCost { get; set; } = 1;


        public override int BuffLife { get; set; } = 1;
        public override string Describe { get; set; } = "";

        public override Rarity Rare { get; set; } = Rarity.普通;

        public override string Name { get; set; } = "雏龙";
        public override string BackgroudImage { get; set; } = "Classical/Whelp.jpg";
        public override bool IsDerivative { get; set; } = true;
        public override Profession Profession { get; set; } = Profession.Neutral;
        public override Race Race => Race.龙;
    }
}
