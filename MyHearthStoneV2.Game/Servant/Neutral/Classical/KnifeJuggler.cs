using MyHearthStoneV2.CardLibrary.CardAbility;
using MyHearthStoneV2.CardLibrary.CardAbility.Observer;
using System.Collections.Generic;

namespace MyHearthStoneV2.CardLibrary.Servant.Neutral.Classical
{
    public class KnifeJuggler : BaseServant
    {
        public override int Damage { get; set; } = 3;
        public override int Life { get; set; } = 2;
        public override int Cost { get; set; } = 2;

        public override string Describe
        {
            get
            {
                return "";
            }
        }

        public override Rarity Rare
        {
            get
            {
                return Rarity.精良;
            }
        }

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new CA_KnifeJuggler() };


        public override string Name
        {
            get
            {
                return "飞刀杂耍者";
            }
        }

        public override string BackgroudImage { get; set; } = "w12_a081_D_1.png";
    }
}
