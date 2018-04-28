using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Hero;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Assert.ActionPrameter.SecondaryCard;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.DynamicNumber;
using MyHearthStoneV2.Game.CardLibrary.Filter.Extract.Card;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Equip.Neutral.Classical
{
    public class WarglaiveOfAzzinoth : BaseEquip
    {
        public override string Name { get; set; } = "埃辛诺斯战刃";

        public override string BackgroudImage { get; set; } = "W19_a256_D.png";

        public override int Damage { get; set; } = 3;
        public override int Durable { get; set; } = 3;

        public override int InitialDamege { get; set; } = 3;

        public override bool IsDerivative => true;

        public override List<ICardAbility> Abilities { get; set; } = new List<ICardAbility>() {
            new HeroAttackingDriver<
                Assert<
                    SecondaryCardIsHero,
                    DoubleAbility<
                        Silence<SecondaryFilter>,
                        ArmorPenetration<SecondaryHeroFilter,ExtractCardDamage<SecondaryFilter>>
                        >,
                    Silence<SecondaryFilter>
                    >,
                InDeskFilter>()
        };

        public override string Describe { get; set; } = "攻击目标是随从时，沉默该随从；攻击目标是英雄时，去除所有奥秘，无视护甲";
        public override Profession Profession { get; set; } = Profession.Neutral;
    }
}
