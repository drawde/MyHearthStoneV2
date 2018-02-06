
using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;

using MyHearthStoneV2.Game.CardLibrary.Servant;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Shaman.Classical
{
    public class Al_akir : BaseServant
    {
        public override int Damage { get; set; } = 3;
        public override int Life { get; set; } = 4;
        public override int Cost { get; set; } = 8;

        public override int InitialDamage { get; set; } = 3;
        public override int InitialLife { get; set; } = 4;
        public override int InitialCost { get; set; } = 8;
        
        public override int BuffLife { get; set; } = 4;
        public override CardLocation CardLocation { get; set; }

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new Taunt(), new Windfury(), new Charge(), new HolyShield() };
        public override string Describe { get; set; } = "风怒，冲锋，圣盾，嘲讽";

        public override Rarity Rare { get; set; } = Rarity.传说;

        public override string Name { get; set; } = "风领主奥拉基尔";
        public override string BackgroudImage { get; set; } = "W14_a190_D.png";

        public override Profession Profession { get; set; } = Profession.Shaman;
        public override Race Race { get; set; } = Race.元素;
    }
}
