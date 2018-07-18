using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.Widget.Condition.DamageType;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter.Servant;
using System.Collections.Generic;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.Spell.Single;
using BattleForAzeroth.Game.Widget.Filter.Context;
using BattleForAzeroth.Game.Widget.Filter.Servant;
using BattleForAzeroth.Game.CardLibrary.Servant.Warlock;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Container;
using BattleForAzeroth.Game.Widget.Filter.PickCard;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;

namespace BattleForAzeroth.Game.CardLibrary.Spell.Warlock
{
    public class Implosion : BaseSpell
    {
        public override Rarity Rare => Rarity.普通;

        public override string Name => "小鬼爆破";
        public override int Cost { get; set; }  = 4;
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

        public override int Damage { get; set; }  = 4;
    }
}
