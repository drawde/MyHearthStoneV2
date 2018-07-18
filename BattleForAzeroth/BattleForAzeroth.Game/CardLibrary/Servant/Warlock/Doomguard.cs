using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Widget.Filter.Context;
using System.Collections.Generic;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;
using BattleForAzeroth.Game.Widget.Condition.Pick;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Warlock
{
    public class Doomguard : BaseServant
    {
        public override int Damage { get; set; }  = 5;
        public override int Life { get; set; }  = 7;
        public override int Cost { get; set; }  = 5;

        public override int InitialDamage => 5;
        public override int InitialLife => 7;
        public override int InitialCost => 5;

        
        public override int BuffLife { get; set; }  = 7;

        public override string Describe => "冲锋，战吼：随机弃2张牌。";

        public override Rarity Rare => Rarity.精良;

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {            
            new NoneTargetBattlecryDriver<DropCard<PrimaryUserContextFilter,Two,RandomPick>>()
        };
        public override bool HasCharge => true;
        public override string BackgroudImage => "W11_141_D_1.png";

        public override string Name => "末日守卫";
        public override Profession Profession => Profession.Warlock;
        public override Race Race => Race.恶魔;
    }
}
