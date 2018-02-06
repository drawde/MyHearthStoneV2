using MyHearthStoneV2.Game.CardLibrary.CardAbility;

using MyHearthStoneV2.Game.CardLibrary.Servant;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.NAXX
{
    public class XiaoZhiZhu : BaseServant
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

        //public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new CA_ServantAttack() };
        public override string Name { get; set; } = "鬼灵蜘蛛";
        public override Profession Profession { get; set; } = Profession.Neutral;
    }
}
