using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Context;
using System.Collections.Generic;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;

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

        public override List<ICardAbility> Abilities { get; set; } = new List<ICardAbility>()
        {
            new NoneTargetBattlecryDriver<DrawCard<MainUserContextFilter,ONE>,NullFilter>(),
            new SpellPower()
        };


        public override string Name { get; set; } = "碧蓝幼龙";
        public override string BackgroudImage { get; set; } = "Classical/AzureDrake.jpg";

        public override Profession Profession { get; set; } = Profession.Neutral;
    }
}
