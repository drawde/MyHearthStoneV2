using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Widget.Condition.DamageType;
using System.Collections.Generic;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter.Hero;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Warlock
{
    public class FlameImp : BaseServant
    {
        public override int Damage { get; set; }  = 3;
        public override int Life { get; set; }  = 2;
        public override int Cost { get; set; }  = 1;

        public override int InitialDamage => 3;
        public override int InitialLife => 2;
        public override int InitialCost => 1;

        public override int BuffLife { get; set; }  = 2;

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
