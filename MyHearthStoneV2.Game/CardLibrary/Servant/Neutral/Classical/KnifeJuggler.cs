using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.Widget.Condition.DamageType;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class KnifeJuggler : BaseServant
    {
        public override int Damage => 3;
        public override int Life => 2;
        public override int Cost => 2;

        public override int InitialDamage => 3;
        public override int InitialLife => 2;
        public override int InitialCost => 2;


        public override int BuffLife => 2;
        public override string Describe => "每当你召唤一个随从时，对一个随机敌方角色造成1点伤害。";

        public override Rarity Rare => Rarity.精良;

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new CastMyServantDriver<RiseDamage<AllSecondaryRandomBiologyFilter,ONE,ONE,PhysicalDamage>,InDeskFilter>(),
            //new CA_KnifeJuggler()
        };


        public override string Name => "飞刀杂耍者";

        public override string BackgroudImage => "w12_a081_D_1.png";

        public override Profession Profession => Profession.Neutral;
    }
}
