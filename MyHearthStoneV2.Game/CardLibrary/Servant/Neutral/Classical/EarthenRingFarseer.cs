using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.Widget.Number;
using System.Collections.Generic;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class EarthenRingFarseer : BaseServant
    {
        public override int Damage { get; set; }  = 3;
        public override int Life { get; set; }  = 3;
        public override int Cost { get; set; }  = 3;

        public override int InitialDamage => 3;
        public override int InitialLife => 3;
        public override int InitialCost => 3;

        public override int BuffLife { get; set; }  = 3;
        public override string Describe => "战吼：恢复3点生命值。";

        public override Rarity Rare => Rarity.普通;

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new AllTargetBattlecryDriver<Heal<SecondaryFilter,Three>>()
        };

        public override string Name => "大地之环先知";
        public override Profession Profession => Profession.Neutral;
        public override string BackgroudImage => "Classical/EarthenRingFarseer.jpg";
    }
}
