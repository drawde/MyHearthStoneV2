using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.DamageType;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Servant;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
using System.Collections.Generic;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Spell.Single;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Assert.Injured;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Context;
using MyHearthStoneV2.Game.CardLibrary.Filter.Servant;
using MyHearthStoneV2.Game.CardLibrary.Servant.Warlock;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Container;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Warlock
{
    public class Implosion : BaseSpell
    {
        public override Rarity Rare { get; set; } = Rarity.普通;

        public override string Name { get; set; } = "小鬼爆破";
        public override int Cost { get; set; } = 4;
        public override int InitialCost { get; set; } = 4;
        public override string Describe { get; set; } = "对一个随从造成2-4点伤害，每造成1点伤害，召唤一个1/1的小鬼。";

        public override List<ICardAbility> Abilities { get; set; } = new List<ICardAbility>()
        {
            new SpellDriver_Single_AllEnemyServant<
                NumberContainer<
                    DoubleAbility<
                        RiseDamage<SecondaryServantFilter,ContainerNumber,ONE,SpellDamage>,
                        Summon<MainUserContextFilter,AssignServantFilter<Imp>,ContainerNumber>
                        >,
                    RandomNumber<Two,Four>
                >,
                NullFilter>()
        };

        public override string BackgroudImage { get; set; } = "GVG/Implosion.jpg";
        public override Profession Profession { get; set; } = Profession.Warlock;

        public override int Damage { get; set; } = 4;
    }
}
