using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter.Servant;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.Widget.Condition.Assert.Number.More;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Widget.Extract.Card;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Warrior
{
    public class WarsongCommander : BaseServant
    {
        public override int Damage => 2;
        public override int Life => 3;
        public override int Cost => 3;

        public override int InitialDamage => 2;
        public override int InitialLife => 3;
        public override int InitialCost => 3;


        public override int BuffLife => 3;

        public override string Describe => "每当你召唤一个攻击力小于或等于3的随从，使该随从获得冲锋";

        public override Rarity Rare => Rarity.史诗;

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new CastMyServantDriver<
                Assert<LessThan<ExtractCardDamage<PrimaryServantFilter,InDeskFilter>,Four>,Charge<PrimaryServantFilter>,Null>,
                    InDeskFilter>()
        };


        public override string Name => "战歌指挥官";

        public override string BackgroudImage => "W11_101_D_1.png";
        public override Profession Profession => Profession.Warrior;
    }
}