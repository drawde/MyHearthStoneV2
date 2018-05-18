using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Widget.Filter.Context;
using System.Collections.Generic;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class AzureDrake : BaseServant
    {
        public override int Damage => 4;
        public override int Life => 4;
        public override int Cost => 5;

        public override int InitialDamage => 4;
        public override int InitialLife => 4;
        public override int InitialCost => 5;


        public override int BuffLife => 4;
        public override string Describe => "法术伤害+1，战吼：抽一张牌。";

        public override Rarity Rare => Rarity.精良;

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new NoneTargetBattlecryDriver<DrawCard<PrimaryUserContextFilter,ONE>>(),
        };


        public override string Name => "碧蓝幼龙";
        public override string BackgroudImage => "Classical/AzureDrake.jpg";

        public override Profession Profession => Profession.Neutral;
        public override int SpellPower => 1;
    }
}
