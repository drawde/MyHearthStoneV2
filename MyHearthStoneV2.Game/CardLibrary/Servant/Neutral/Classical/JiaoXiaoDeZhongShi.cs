
using MyHearthStoneV2.Game.CardLibrary.CardAbility;

using MyHearthStoneV2.Game.CardLibrary.CardAbility.WarCry.AlterBody;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class JiaoXiaoDeZhongShi : BaseServant
    {
        public override int Damage { get; set; } = 2;
        public override int Life { get; set; } = 1;
        public override int Cost { get; set; } = 1;

        public override int InitialDamage { get; set; } = 2;
        public override int InitialLife { get; set; } = 1;
        public override int InitialCost { get; set; } = 1;
        
        public override int BuffLife { get; set; } = 1;

        public override string Describe { get; set; } = "战吼：在本回合中，使一个随从获得 +2 攻击力。";

        public override Rarity Rare { get; set; } = Rarity.普通;

        public override List<ICardAbility> Abilities { get; set; } = new List<ICardAbility>() { new CA_JiaoXiaoDeZhongShi() };

        public override string BackgroudImage { get; set; } = "W2_326_D.png";

        public override string Name { get; set; } = "叫嚣的中士";
        public override Profession Profession { get; set; } = Profession.Neutral;
    }
}
