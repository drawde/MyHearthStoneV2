using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.DamageType;
using System.Collections.Generic;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Hero;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Warlock
{
    public class FlameImp : BaseServant
    {
        public override int Damage { get; set; } = 3;
        public override int Life { get; set; } = 2;
        public override int Cost { get; set; } = 1;

        public override int InitialDamage { get; set; } = 3;
        public override int InitialLife { get; set; } = 2;
        public override int InitialCost { get; set; } = 1;

        public override int BuffLife { get; set; } = 2;

        public override string Describe { get; set; } = "战吼：对你的英雄造成3点伤害。";

        public override Rarity Rare { get; set; } = Rarity.普通;

        public override List<ICardAbility> Abilities { get; set; } = new List<ICardAbility>()
        {
            new NoneTargetBattlecryDriver<RiseDamage<MainHeroFilter,Three,ONE,PhysicalDamage>>(),
        };

        public override string BackgroudImage { get; set; } = "W7_009_D.png";

        public override string Name { get; set; } = "烈焰小鬼";
        public override Profession Profession { get; set; } = Profession.Warlock;
        public override Race Race { get; set; } = Race.恶魔;
    }
}
