using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.Widget.Condition.DamageType;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter;
using System.Collections.Generic;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class MadBomber : BaseServant
    {
        public override int Damage => 3;
        public override int Life => 2;
        public override int Cost => 2;

        public override int InitialDamage => 3;
        public override int InitialLife => 2;
        public override int InitialCost => 2;


        public override int BuffLife => 2;
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
