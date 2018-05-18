using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.Widget.Condition.DamageType;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using System.Collections.Generic;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Rogue
{
    public class SI7Agent : BaseServant
    {
        public override int Damage => 3;
        public override int Life => 3;
        public override int Cost => 3;

        public override int InitialDamage => 3;
        public override int InitialLife => 3;
        public override int InitialCost => 3;

        public override int BuffLife => 3;
        public override string Describe => "连击：造成2点伤害。";

        public override Rarity Rare => Rarity.精良;

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new AllServantBattlecryDriver<ComboDriver<Null,RiseDamage<SecondaryFilter,Two,ONE,PhysicalDamage>,NullFilter>>(),
            //new CA_SI7Agent()
        };

        public override string Name => "军情七处特工";
        public override Profession Profession => Profession.Rogue;
        public override string BackgroudImage => "Classical/SI7Agent.jpg";
    }
}
