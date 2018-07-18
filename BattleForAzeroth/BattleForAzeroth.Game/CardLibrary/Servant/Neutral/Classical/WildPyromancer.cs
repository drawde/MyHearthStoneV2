using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Condition.DamageType;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter.Servant;
using System.Collections.Generic;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Neutral.Classical
{
    public class WildPyromancer : BaseServant
    {
        public override int Damage { get; set; }  = 3;
        public override int Life { get; set; }  = 2;
        public override int Cost { get; set; }  = 2;

        public override int InitialDamage => 3;
        public override int InitialLife => 2;
        public override int InitialCost => 2;
        
        public override int BuffLife { get; set; }  = 2;

        public override string Describe => "每当你施放一个法术时，对所有随从造成1点伤害。";

        public override Rarity Rare => Rarity.精良;

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new AfterICastSpellDriver<RiseDamage<AllServantFilter,ONE,ONE,SpellDamage>,InDeskFilter>()            
        };

        public override string BackgroudImage => "W6_011_D.png";

        public override string Name => "狂野炎术师";
        public override Profession Profession => Profession.Neutral;
    }
}
