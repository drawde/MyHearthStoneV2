using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Condition.DamageType;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Widget.Filter.Context;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter.Servant;
using System.Collections.Generic;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.Spell;

namespace BattleForAzeroth.Game.CardLibrary.Spell.Rogue
{
    public class FanofKnives : BaseSpell
    {
        public override Rarity Rare => Rarity.普通;

        public override string Name => "刀扇";
        public override int Cost { get; set; }  = 3;
        public override int InitialCost => 3;
        public override string Describe => "对所有敌方随从造成1点伤害，抽一张牌。";

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {            
            new NoneTargetSpellDriver<
                DoubleActionDriver<
                    RiseDamage<AllEnemyServantFilter,ONE,ONE,SpellDamage>,
                    DrawCard<PrimaryUserContextFilter,ONE>,
                NullFilter>>(),
            //new CA_FanofKnives()
        };

        public override string BackgroudImage => "Classical/FanofKnives.jpg";
        public override Profession Profession => Profession.Rogue;

        public override int Damage { get; set; }  = 1;
    }
}
