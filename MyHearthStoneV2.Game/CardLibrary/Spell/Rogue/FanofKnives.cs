using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.DamageType;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Quantity;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Context;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Servant;
using System.Collections.Generic;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Rogue
{
    public class FanofKnives : BaseSpell
    {
        public override Rarity Rare { get; set; } = Rarity.普通;

        public override string Name { get; set; } = "刀扇";
        public override int Cost { get; set; } = 3;
        public override int InitialCost { get; set; } = 3;
        public override string Describe { get; set; } = "对所有敌方随从造成1点伤害，抽一张牌。";

        public override List<IBaseCardAbility> Abilities { get; set; } = new List<IBaseCardAbility>()
        {            
            new SpellDriver<DoubleActionDriver<RiseDamage<AllEnemyServantFilter,ONE,ONE,SpellDamage>,DrawCard<MainUserContextFilter,ONE>,NullFilter>,NullFilter>(),
            //new CA_FanofKnives()
        };

        public override string BackgroudImage { get; set; } = "Classical/FanofKnives.jpg";
        public override Profession Profession { get; set; } = Profession.Rogue;

        public override int Damage { get; set; } = 1;
    }
}
