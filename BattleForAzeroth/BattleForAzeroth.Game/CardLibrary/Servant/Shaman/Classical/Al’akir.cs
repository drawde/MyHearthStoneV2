
using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;

using BattleForAzeroth.Game.CardLibrary.Servant;
using System.Collections.Generic;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Shaman.Classical
{
    public class Al_akir : BaseServant
    {
        public override int Damage { get; set; }  = 3;
        public override int Life { get; set; }  = 4;
        public override int Cost { get; set; }  = 8;

        public override int InitialDamage => 3;
        public override int InitialLife => 4;
        public override int InitialCost => 8;
        
        public override int BuffLife { get; set; }  = 4;
        public override CardLocation CardLocation { get; set; }

        public override List<ICardAbility> Abilities => new List<ICardAbility>() { };
        public override string Describe => "风怒，冲锋，圣盾，嘲讽";

        public override Rarity Rare => Rarity.传说;

        public override string Name => "风领主奥拉基尔";
        public override string BackgroudImage => "W14_a190_D.png";

        public override Profession Profession => Profession.Shaman;
        public override Race Race => Race.元素;
        public override bool HasCharge => true;
        public override bool HasTaunt => true;
        public override bool HasWindfury => true;
        public override bool HasHolyShield => true;
    }
}
