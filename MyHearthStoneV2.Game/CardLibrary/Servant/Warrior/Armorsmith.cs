using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Quantity;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Warrior
{
    public class Armorsmith : BaseServant
    {
        public override int Damage { get; set; } = 1;
        public override int Life { get; set; } = 4;
        public override int Cost { get; set; } = 2;

        public override int InitialDamage { get; set; } = 1;
        public override int InitialLife { get; set; } = 4;
        public override int InitialCost { get; set; } = 2;

        
        public override int BuffLife { get; set; } = 4;

        public override string Describe { get; set; } = "每当一个友方随从受到伤害，便获得1点护甲值。";

        public override Rarity Rare { get; set; } = Rarity.精良;

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>()
        {
            new MyServantHurtObserverDriver<AddAmmo<ONE>>(),
        };

        public override string BackgroudImage { get; set; } = "W10_A047_D.png";

        public override string Name { get; set; } = "铸甲师";
        public override Profession Profession { get; set; } = Profession.Warrior;
    }
}
