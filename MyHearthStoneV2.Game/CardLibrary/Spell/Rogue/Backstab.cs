using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Spell.Single;
using MyHearthStoneV2.Game.Widget.Condition.DamageType;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter.Servant;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Rogue
{
    public class Backstab : BaseSpell
    {
        public override Rarity Rare => Rarity.普通;

        public override string Name => "背刺";
        public override int Cost => 0;
        public override int InitialCost => 0;
        public override string Describe => "对一个未受伤害的随从造成2点伤害。";

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new SpellDriver_Single_AllEnemyServant<RiseDamage<SecondaryServantFilter,Two,ONE,SpellDamage>>(),
        };

        public override string BackgroudImage => "Classical/Backstab.jpg";
        public override Profession Profession => Profession.Rogue;

        public override CastCardPrecondition CastCardPrecondition => CastCardPrecondition.健康;
        public override int Damage => 2;
    }
}
