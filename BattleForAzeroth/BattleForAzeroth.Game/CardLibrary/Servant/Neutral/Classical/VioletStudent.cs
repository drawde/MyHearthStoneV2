
using BattleForAzeroth.Game.CardLibrary.CardAbility;

using BattleForAzeroth.Game.CardLibrary.Servant;
using System.Collections.Generic;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Neutral.Classical
{
    public class VioletStudent : BaseServant
    {
        public override int Damage { get; set; }  = 1;
        public override int Life { get; set; }  = 1;
        public override int Cost { get; set; }  = 1;

        public override int InitialDamage => 1;
        public override int InitialLife => 1;
        public override int InitialCost => 1;

        
        public override int BuffLife { get; set; }  = 1;
        public override bool IsDerivative => true;
        public override string Describe => "";

        public override Rarity Rare => Rarity.普通;
        public override string Name => "紫罗兰学徒";
        //public override List<BaseCardAbility> Abilities => new List<BaseCardAbility>() {  };
        public override string BackgroudImage => "WOW_EQU_050_D.png";
        public override Profession Profession => Profession.Neutral;
    }
}
