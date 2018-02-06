using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using System.Collections.Generic;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Observer;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class Patchwerk : BaseServant
    {
        public override int Damage { get; set; } = 4;
        public override int Life { get; set; } = 10;
        public override int Cost { get; set; } = 9;

        public override int InitialDamage { get; set; } = 4;
        public override int InitialLife { get; set; } = 10;
        public override int InitialCost { get; set; } = 9;

        
        public override int BuffLife { get; set; } = 10;
        public override string Describe { get; set; } = "当他的攻击目标为英雄时，无视护甲并造成双倍伤害";

        public override Rarity Rare => Rarity.传说;

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new CA_Patchwerk() };


        public override string Name { get; set; } = "帕奇维克";
        public override string BackgroudImage { get; set; } = "r5_a005_D_1.png";

        public override Profession Profession { get; set; } = Profession.Neutral;
    }
}
