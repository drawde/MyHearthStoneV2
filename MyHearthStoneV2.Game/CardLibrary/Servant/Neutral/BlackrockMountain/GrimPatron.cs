using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Observer;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.BlackrockMountain
{
    public class GrimPatron : BaseServant
    {
        public override int Damage { get; set; } = 3;
        public override int Life { get; set; } = 3;
        public override int Cost { get; set; } = 5;

        public override int InitialDamage { get; set; } = 3;
        public override int InitialLife { get; set; } = 3;
        public override int InitialCost { get; set; } = 5;

        
        public override int BuffLife { get; set; } = 3;
        public override string Describe { get; set; } = "每当该随从受到伤害并没有死亡，召唤另一个恐怖的奴隶主。";

        public override Rarity Rare { get; set; } = Rarity.精良;

        public override List<IBaseCardAbility> Abilities { get; set; } = new List<IBaseCardAbility>() { new CA_GrimPatron() };
        public override string BackgroudImage { get; set; } = "BlackrockMountain/GrimPatron.jpg"; 

        public override string Name { get; set; } = "恐怖奴隶主";
        public override Profession Profession { get; set; } = Profession.Neutral;
    }
}
