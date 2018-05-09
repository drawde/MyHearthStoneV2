using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class KoboldGeomancer : BaseServant
    {
        public override int Damage { get; set; } = 2;
        public override int Life { get; set; } = 2;
        public override int Cost { get; set; } = 2;

        public override int InitialDamage { get; set; } = 2;
        public override int InitialLife { get; set; } = 2;
        public override int InitialCost { get; set; } = 2;


        public override int BuffLife { get; set; } = 2;
        public override string Describe { get; set; } = "法术伤害+1。";

        public override Rarity Rare { get; set; } = Rarity.普通;     

        public override string Name { get; set; } = "狗头人地卜师";
        public override string BackgroudImage { get; set; } = "Classical/KoboldGeomancer.jpg";

        public override Profession Profession { get; set; } = Profession.Neutral;
        public override int SpellPower => 1;
    }
}
