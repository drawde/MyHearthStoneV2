using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Observer;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Warrior
{
    public class WarsongCommander : BaseServant
    {
        public override int Damage { get; set; } = 2;
        public override int Life { get; set; } = 3;
        public override int Cost { get; set; } = 3;

        public override int InitialDamage { get; set; } = 2;
        public override int InitialLife { get; set; } = 3;
        public override int InitialCost { get; set; } = 3;


        public override int BuffDamage { get; set; } = 2;
        public override int BuffLife { get; set; } = 3;
        public override int BuffCost { get; set; } = 3;

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
                return Rarity.史诗;
            }
        }

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new CA_WarsongCommander() };


        public override string Name { get; set; } = "战歌指挥官";

        public override string BackgroudImage { get; set; } = "W11_101_D_1.png";
        public override Profession Profession { get; set; } = Profession.Warrior;
    }
}
