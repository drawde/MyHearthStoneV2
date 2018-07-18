using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Condition.DamageType;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using System.Collections.Generic;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Neutral.Classical
{
    public class KnifeJuggler : BaseServant
    {
        public override int Damage { get; set; }  = 3;
        public override int Life { get; set; }  = 2;
        public override int Cost { get; set; }  = 2;

        public override int InitialDamage => 3;
        public override int InitialLife => 2;
        public override int InitialCost => 2;


        public override int BuffLife { get; set; }  = 2;
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
