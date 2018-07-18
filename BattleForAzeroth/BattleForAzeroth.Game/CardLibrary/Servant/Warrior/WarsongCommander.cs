using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter.Servant;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.Widget.Condition.Assert.Number.More;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Widget.Extract.Card;
using System.Collections.Generic;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Warrior
{
    public class WarsongCommander : BaseServant
    {
        public override int Damage { get; set; }  = 2;
        public override int Life { get; set; }  = 3;
        public override int Cost { get; set; }  = 3;

        public override int InitialDamage => 2;
        public override int InitialLife => 3;
        public override int InitialCost => 3;


        public override int BuffLife { get; set; }  = 3;

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