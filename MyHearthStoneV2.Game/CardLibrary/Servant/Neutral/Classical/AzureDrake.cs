using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Quantity;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Context;
using System.Collections.Generic;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class AzureDrake : BaseServant
    {
        public override int Damage { get; set; } = 4;
        public override int Life { get; set; } = 4;
        public override int Cost { get; set; } = 5;

        public override int InitialDamage { get; set; } = 4;
        public override int InitialLife { get; set; } = 4;
        public override int InitialCost { get; set; } = 5;


        public override int BuffLife { get; set; } = 4;
        public override string Describe { get; set; } = "法术伤害+1，战吼：抽一张牌。";

        public override Rarity Rare { get; set; } = Rarity.精良;

        public override List<IBaseCardAbility> Abilities { get; set; } = new List<IBaseCardAbility>()
        {
            new BattlecryDriver<DrawCard<MainUserContextFilter,ONE>,NullFilter>(),//() { DrawCount = 1, AbilityType = AbilityType.战吼 },
            new SpellPower()
        };


        public override string Name { get; set; } = "碧蓝幼龙";
        public override string BackgroudImage { get; set; } = "Classical/AzureDrake.jpg";

        public override Profession Profession { get; set; } = Profession.Neutral;
    }
}
