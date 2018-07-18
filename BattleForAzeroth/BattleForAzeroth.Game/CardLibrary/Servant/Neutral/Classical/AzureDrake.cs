using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Widget.Filter.Context;
using System.Collections.Generic;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Neutral.Classical
{
    public class AzureDrake : BaseServant
    {
        public override int Damage { get; set; }  = 4;
        public override int Life { get; set; }  = 4;
        public override int Cost { get; set; }  = 5;

        public override int InitialDamage => 4;
        public override int InitialLife => 4;
        public override int InitialCost => 5;


        public override int BuffLife { get; set; }  = 4;
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
