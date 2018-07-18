using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter.Hero;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.Widget.Condition.Assert.ActionPrameter.SecondaryCard;
using BattleForAzeroth.Game.Widget.Number.DynamicNumber;
using BattleForAzeroth.Game.Widget.Extract.Card;
using System.Collections.Generic;

namespace BattleForAzeroth.Game.CardLibrary.Equip.Neutral.Classical
{
    public class WarglaiveOfAzzinoth : BaseEquip
    {
        public override string Name => "埃辛诺斯战刃";

        public override string BackgroudImage => "W19_a256_D.png";

        public override int Damage { get; set; } = 3;
        public override int Durable { get; set; } = 3;

        public override int InitialDamege => 3;

        public override bool IsDerivative => true;

        public override List<ICardAbility> Abilities => new List<ICardAbility>() {
            new HeroAttackingDriver<
                Assert
                <
                    SecondaryCardIsHero,
                    DoubleAbility
                    <
                        Silence<SecondaryFilter>,
                        ArmorPenetration<SecondaryHeroFilter,ExtractCardDamage<SecondaryFilter,InDeskFilter>>
                    >,
                    Silence<SecondaryFilter>
                >,
                InDeskFilter>()
        };

        public override string Describe => "攻击目标是随从时，沉默该随从；攻击目标是英雄时，去除所有奥秘，无视护甲";
        public override Profession Profession => Profession.Neutral;
    }
}
