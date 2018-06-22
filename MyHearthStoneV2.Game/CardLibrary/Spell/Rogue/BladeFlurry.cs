using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.Widget.Condition.DamageType;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter.Hero;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Spell;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Widget.Extract.Card;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Rogue
{
    public class BladeFlurry : BaseSpell
    {
        public override Rarity Rare => Rarity.普通;

        public override string Name => "剑刃乱舞";
        public override int Cost { get; set; }  = 2;
        public override int InitialCost => 2;
        public override string Describe => "摧毁你的武器，对所有敌方角色造成等同于其攻击力的伤害。";

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new NoneTargetSpellDriver<
                DoubleAbility<
                    RiseDamage<AllPrimaryEnemyFilter,ExtractCardDamage<PrimaryHeroFilter,InDeskFilter>,ONE,SpellDamage>,
                    DestroyEquip<PrimaryHeroFilter>>>()
        };

        public override string BackgroudImage => "Classical/BladeFlurry.jpg";
        public override Profession Profession => Profession.Rogue;

        public override CastCardPrecondition CastCardPrecondition => CastCardPrecondition.装备有武器;
    }
}
