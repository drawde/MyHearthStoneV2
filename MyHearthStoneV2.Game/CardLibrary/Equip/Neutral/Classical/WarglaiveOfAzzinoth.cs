using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter.Hero;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.Widget.Condition.Assert.ActionPrameter.SecondaryCard;
using MyHearthStoneV2.Game.Widget.Number.DynamicNumber;
using MyHearthStoneV2.Game.Widget.Extract.Card;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Equip.Neutral.Classical
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
