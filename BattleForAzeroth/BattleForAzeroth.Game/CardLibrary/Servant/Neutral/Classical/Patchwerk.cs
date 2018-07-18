using BattleForAzeroth.Game.CardLibrary.CardAbility;
using System.Collections.Generic;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.Widget.Condition.Assert.ActionPrameter.SecondaryCard;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter.Hero;
using BattleForAzeroth.Game.Widget.Extract.Card;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;
using BattleForAzeroth.Game.Widget.Number.DynamicNumber;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Neutral.Classical
{
    public class Patchwerk : BaseServant
    {
        public override int Damage { get; set; }  = 4;
        public override int Life { get; set; }  = 10;
        public override int Cost { get; set; }  = 9;

        public override int InitialDamage => 4;
        public override int InitialLife => 10;
        public override int InitialCost => 9;

        
        public override int BuffLife { get; set; }  = 10;
        public override string Describe => "当他的攻击目标为英雄时，无视护甲并造成双倍伤害";

        public override Rarity Rare => Rarity.传说;

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new ServantAttackingDriver<
                Assert<
                    SecondaryCardIsHero,
                    ArmorPenetration<SecondaryHeroFilter,DynamicDoubleNumber<ExtractCardDamage<SecondaryFilter,InDeskFilter>>>,
                    Null
                    >,
                InDeskFilter>()
        };


        public override string Name => "帕奇维克";
        public override string BackgroudImage => "r5_a005_D_1.png";

        public override Profession Profession => Profession.Neutral;
    }
}
