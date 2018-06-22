using MyHearthStoneV2.Game.CardLibrary.CardAbility;

using MyHearthStoneV2.Game.CardLibrary.Servant;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.NAXX
{
    public class XiaoZhiZhu : BaseServant
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

        //public override List<BaseCardAbility> Abilities => new List<BaseCardAbility>() { new CA_ServantAttack() };
        public override string Name => "鬼灵蜘蛛";
        public override Profession Profession => Profession.Neutral;
    }
}
