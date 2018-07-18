using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Condition.DamageType;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;
using System.Collections.Generic;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Neutral.Classical
{
    public class MadBomber : BaseServant
    {
        public override int Damage { get; set; }  = 3;
        public override int Life { get; set; }  = 2;
        public override int Cost { get; set; }  = 2;

        public override int InitialDamage => 3;
        public override int InitialLife => 2;
        public override int InitialCost => 2;


        public override int BuffLife { get; set; }  = 2;
        public override string Describe => "战吼：造成3点伤害，随机由所有其他角色分摊。";

        public override Rarity Rare => Rarity.普通;

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new NoneTargetBattlecryDriver<RiseDamage<DeskCardRandomFilter,ONE,Three,PhysicalDamage>>(),
        };


        public override string Name => "疯狂投弹者";
        public override string BackgroudImage => "Classical/MadBomber.jpg";

        public override Profession Profession => Profession.Neutral;
    }
}
