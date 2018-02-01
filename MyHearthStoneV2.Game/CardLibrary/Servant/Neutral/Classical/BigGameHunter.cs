using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.WarCry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class BigGameHunter : BaseServant
    {
        public override int Damage { get; set; } = 4;
        public override int Life { get; set; } = 2;
        public override int Cost { get; set; } = 3;

        public override int InitialDamage { get; set; } = 4;
        public override int InitialLife { get; set; } = 2;
        public override int InitialCost { get; set; } = 3;

        public override int BuffDamage { get; set; } = 4;
        public override int BuffLife { get; set; } = 2;
        public override int BuffCost { get; set; } = 3;

        public override string Describe { get; set; } = "战吼：消灭一个攻击力大于或等于7的随从。";

        public override Rarity Rare { get; set; } = Rarity.史诗;

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new CA_BigGameHunter() };

        public override string BackgroudImage { get; set; } = "W5_030_D.png";

        public override string Name { get; set; } = "王牌猎手";
        public override Profession Profession { get; set; } = Profession.Neutral;
    }
}
