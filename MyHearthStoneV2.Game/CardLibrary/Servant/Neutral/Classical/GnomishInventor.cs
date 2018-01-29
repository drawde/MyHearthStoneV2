using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class GnomishInventor : BaseServant
    {
        public override int Damage { get; set; } = 2;
        public override int Life { get; set; } = 4;
        public override int Cost { get; set; } = 4;

        public override int InitialDamage { get; set; } = 2;
        public override int InitialLife { get; set; } = 4;
        public override int InitialCost { get; set; } = 4;


        public override int BuffDamage { get; set; } = 2;
        public override int BuffLife { get; set; } = 4;
        public override int BuffCost { get; set; } = 4;
        public override string Describe
        {
            get
            {
                return "战吼：抽一张牌。";
            }
        }

        public override Rarity Rare
        {
            get
            {
                return Rarity.普通;
            }
        }

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new DrawCard() { DrawCount = 1, AbilityType = AbilityType.战吼 } };


        public override string Name { get; set; } = "侏儒发明家";
        public override string BackgroudImage { get; set; } = "W7_031_D.png";

        public override Profession Profession { get; set; } = Profession.Neutral;
    }
}
