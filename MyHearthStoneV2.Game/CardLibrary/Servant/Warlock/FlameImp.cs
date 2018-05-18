using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Widget.Condition.DamageType;
using System.Collections.Generic;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter.Hero;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Warlock
{
    public class FlameImp : BaseServant
    {
        public override int Damage => 3;
        public override int Life => 2;
        public override int Cost => 1;

        public override int InitialDamage => 3;
        public override int InitialLife => 2;
        public override int InitialCost => 1;

        public override int BuffLife => 2;

        public override string Describe => "战吼：对你的英雄造成3点伤害。";

        public override Rarity Rare => Rarity.普通;

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new NoneTargetBattlecryDriver<RiseDamage<PrimaryHeroFilter,Three,ONE,PhysicalDamage>>(),
        };

        public override string BackgroudImage => "W7_009_D.png";

        public override string Name => "烈焰小鬼";
        public override Profession Profession => Profession.Warlock;
        public override Race Race => Race.恶魔;
    }
}
