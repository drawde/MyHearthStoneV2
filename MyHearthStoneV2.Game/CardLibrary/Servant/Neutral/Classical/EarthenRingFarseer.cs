using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
using System.Collections.Generic;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class EarthenRingFarseer : BaseServant
    {
        public override int Damage { get; set; } = 3;
        public override int Life { get; set; } = 3;
        public override int Cost { get; set; } = 3;

        public override int InitialDamage { get; set; } = 3;
        public override int InitialLife { get; set; } = 3;
        public override int InitialCost { get; set; } = 3;

        public override int BuffLife { get; set; } = 3;
        public override string Describe { get; set; } = "战吼：恢复3点生命值。";

        public override Rarity Rare { get; set; } = Rarity.普通;

        public override List<ICardAbility> Abilities { get; set; } = new List<ICardAbility>()
        {
            new AllTargetBattlecryDriver<Heal<SecondaryFilter,Three>>()
        };

        public override string Name { get; set; } = "大地之环先知";
        public override Profession Profession { get; set; } = Profession.Neutral;
        public override string BackgroudImage { get; set; } = "Classical/EarthenRingFarseer.jpg";
    }
}
