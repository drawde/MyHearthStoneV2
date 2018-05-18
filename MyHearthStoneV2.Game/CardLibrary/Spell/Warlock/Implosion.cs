using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.Widget.Condition.DamageType;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter.Servant;
using System.Collections.Generic;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Spell.Single;
using MyHearthStoneV2.Game.Widget.Filter.Context;
using MyHearthStoneV2.Game.Widget.Filter.Servant;
using MyHearthStoneV2.Game.CardLibrary.Servant.Warlock;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Container;
using MyHearthStoneV2.Game.Widget.Filter.PickCard;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Warlock
{
    public class Implosion : BaseSpell
    {
        public override Rarity Rare => Rarity.普通;

        public override string Name => "小鬼爆破";
        public override int Cost => 4;
        public override int InitialCost => 4;
        public override string Describe => "对一个随从造成2-4点伤害，每造成1点伤害，召唤一个1/1的小鬼。";

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new SpellDriver_Single_AllEnemyServant<
                NumberContainer<
                    DoubleAbility<
                        RiseDamage<SecondaryServantFilter,ContainerNumber,ONE,SpellDamage>,
                        Summon<PrimaryUserContextFilter,NullFilter,AssignServantFilter<Imp>,AllPickFilter,ContainerNumber>
                        >,
                    RandomNumber<Two,Four>
                >>()
        };

        public override string BackgroudImage => "GVG/Implosion.jpg";
        public override Profession Profession => Profession.Warlock;

        public override int Damage => 4;
    }
}
