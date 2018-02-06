
using MyHearthStoneV2.Game.CardLibrary.CardAbility;

using MyHearthStoneV2.Game.CardLibrary.Servant;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class VioletStudent : BaseServant
    {
        public override int Damage { get; set; } = 1;
        public override int Life { get; set; } = 1;
        public override int Cost { get; set; } = 1;

        public override int InitialDamage { get; set; } = 1;
        public override int InitialLife { get; set; } = 1;
        public override int InitialCost { get; set; } = 1;

        
        public override int BuffLife { get; set; } = 1;
        public override bool IsDerivative { get; set; } = true;
        public override string Describe { get; set; } = "";

        public override Rarity Rare { get; set; } = Rarity.普通;
        public override string Name { get; set; } = "紫罗兰学徒";
        //public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() {  };
        public override string BackgroudImage { get; set; } = "WOW_EQU_050_D.png";
        public override Profession Profession { get; set; } = Profession.Neutral;
    }
}
