using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.Widget.Condition.DamageType;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Widget.Filter.Context;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter.Servant;
using System.Collections.Generic;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Spell;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Rogue
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
