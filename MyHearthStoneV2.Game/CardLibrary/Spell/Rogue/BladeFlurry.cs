using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.DamageType;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Hero;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Spell;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
using MyHearthStoneV2.Game.CardLibrary.Filter.Extract.Card;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Rogue
{
    public class BladeFlurry : BaseSpell
    {
        public override Rarity Rare { get; set; } = Rarity.普通;

        public override string Name { get; set; } = "剑刃乱舞";
        public override int Cost { get; set; } = 2;
        public override int InitialCost { get; set; } = 2;
        public override string Describe { get; set; } = "摧毁你的武器，对所有敌方角色造成等同于其攻击力的伤害。";

        public override List<ICardAbility> Abilities { get; set; } = new List<ICardAbility>()
        {
            new SpellDriver<
                DoubleAbility<
                    RiseDamage<AllMainEnemyFilter,ExtractCardDamage<MainHeroFilter>,ONE,SpellDamage>,
                    DestroyEquip<MainHeroFilter>>,
                NullFilter
                >()
        };

        public override string BackgroudImage { get; set; } = "Classical/BladeFlurry.jpg";
        public override Profession Profession { get; set; } = Profession.Rogue;

        public override CastCardPrecondition CastCardPrecondition { get; set; } = CastCardPrecondition.装备有武器;
    }
}
