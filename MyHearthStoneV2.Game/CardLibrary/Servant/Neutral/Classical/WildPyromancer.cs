using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class WildPyromancer : BaseServant
    {
        public override int Damage { get; set; } = 3;
        public override int Life { get; set; } = 2;
        public override int Cost { get; set; } = 2;

        public override int InitialDamage { get; set; } = 3;
        public override int InitialLife { get; set; } = 2;
        public override int InitialCost { get; set; } = 2;
        
        public override int BuffLife { get; set; } = 2;

        public override string Describe { get; set; } = "每当你施放一个法术时，对所有随从造成1点伤害。";

        public override Rarity Rare { get; set; } = Rarity.精良;

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new CA_WildPyromancer() };

        public override string BackgroudImage { get; set; } = "W6_011_D.png";

        public override string Name { get; set; } = "狂野炎术师";
        public override Profession Profession { get; set; } = Profession.Neutral;
    }
}
