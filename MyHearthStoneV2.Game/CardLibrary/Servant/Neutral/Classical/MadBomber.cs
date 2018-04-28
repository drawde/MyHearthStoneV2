using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.DamageType;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter;
using System.Collections.Generic;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class MadBomber : BaseServant
    {
        public override int Damage { get; set; } = 3;
        public override int Life { get; set; } = 2;
        public override int Cost { get; set; } = 2;

        public override int InitialDamage { get; set; } = 3;
        public override int InitialLife { get; set; } = 2;
        public override int InitialCost { get; set; } = 2;


        public override int BuffLife { get; set; } = 2;
        public override string Describe { get; set; } = "战吼：造成3点伤害，随机由所有其他角色分摊。";

        public override Rarity Rare { get; set; } = Rarity.普通;

        public override List<ICardAbility> Abilities { get; set; } = new List<ICardAbility>()
        {
            new NoneTargetBattlecryDriver<RiseDamage<DeskCardRandomFilter,ONE,Three,PhysicalDamage>,NullFilter>(),
        };


        public override string Name { get; set; } = "疯狂投弹者";
        public override string BackgroudImage { get; set; } = "Classical/MadBomber.jpg";

        public override Profession Profession { get; set; } = Profession.Neutral;
    }
}
