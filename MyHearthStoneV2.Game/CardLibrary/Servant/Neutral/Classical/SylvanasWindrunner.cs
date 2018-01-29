
using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Deathwhisper;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class SylvanasWindrunner : BaseServant
    {
        public override int Damage { get; set; } = 5;
        public override int Life { get; set; } = 5;
        public override int Cost { get; set; } = 6;

        public override int InitialDamage { get; set; } = 5;
        public override int InitialLife { get; set; } = 5;
        public override int InitialCost { get; set; } = 6;

        public override int BuffDamage { get; set; } = 5;
        public override int BuffLife { get; set; } = 5;
        public override int BuffCost { get; set; } = 6;
        public override string Describe => "控制一个随机敌方随从。";

        public override Rarity Rare => Rarity.传说;

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new CA_SylvanasWindrunner() };


        public override string Name { get; set; } = "希尔瓦娜斯·风行者";
        public override string BackgroudImage { get; set; } = "W11_218_D_1.png";
        public override Profession Profession { get; set; } = Profession.Neutral;
    }
}
