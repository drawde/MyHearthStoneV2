using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class Whelp : BaseServant
    {
        public override int Damage => 1;
        public override int Life => 1;
        public override int Cost => 1;

        public override int InitialDamage => 1;
        public override int InitialLife => 1;
        public override int InitialCost => 1;


        public override int BuffLife => 1;
        public override string Describe => "";

        public override Rarity Rare => Rarity.普通;

        public override string Name => "雏龙";
        public override string BackgroudImage => "Classical/Whelp.jpg";
        public override bool IsDerivative => true;
        public override Profession Profession => Profession.Neutral;
        public override Race Race => Race.龙;
    }
}
