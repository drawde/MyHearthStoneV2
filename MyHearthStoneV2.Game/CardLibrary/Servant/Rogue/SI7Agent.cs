using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.DamageType;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Quantity;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Target;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.WarCry;
using System.Collections.Generic;
namespace MyHearthStoneV2.Game.CardLibrary.Servant.Rogue
{
    public class SI7Agent : BaseServant
    {
        public override int Damage { get; set; } = 3;
        public override int Life { get; set; } = 3;
        public override int Cost { get; set; } = 3;

        public override int InitialDamage { get; set; } = 3;
        public override int InitialLife { get; set; } = 3;
        public override int InitialCost { get; set; } = 3;

        public override int BuffLife { get; set; } = 3;
        public override string Describe { get; set; } = "连击：造成2点伤害。";

        public override Rarity Rare { get; set; } = Rarity.精良;

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>()
        {
            new BattlecryDriver<ComboDriver<Null,RiseDamage<SecondaryTarget,Three,ONE,PhysicalDamage>>>(),
            //new CA_SI7Agent()
        };

        public override string Name { get; set; } = "军情七处特工";
        public override Profession Profession { get; set; } = Profession.Rogue;
        public override string BackgroudImage { get; set; } = "Classical/SI7Agent.jpg";
    }
}
