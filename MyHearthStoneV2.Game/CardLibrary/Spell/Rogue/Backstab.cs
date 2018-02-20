using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Spell.Single;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.DamageType;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Quantity;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Servant;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Rogue
{
    public class Backstab : BaseSpell
    {
        public override Rarity Rare { get; set; } = Rarity.普通;

        public override string Name { get; set; } = "背刺";
        public override int Cost { get; set; } = 0;
        public override int InitialCost { get; set; } = 0;
        public override string Describe { get; set; } = "对一个未受伤害的随从造成2点伤害。";

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>()
        {
            new SpellDriver_Single_AllEnemyServant<RiseDamage<SecondaryServantFilter,Two,ONE,SpellDamage>>(),
        };

        public override string BackgroudImage { get; set; } = "Classical/Backstab.jpg";
        public override Profession Profession { get; set; } = Profession.Rogue;

        public override CastCardPrecondition CastCardPrecondition { get; set; } = CastCardPrecondition.健康;
        public override int Damage { get; set; } = 2;
    }
}
