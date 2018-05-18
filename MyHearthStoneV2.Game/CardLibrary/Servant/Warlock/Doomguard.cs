using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Widget.Filter.Context;
using System.Collections.Generic;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;
using MyHearthStoneV2.Game.Widget.Condition.Pick;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Warlock
{
    public class Doomguard : BaseServant
    {
        public override int Damage => 5;
        public override int Life => 7;
        public override int Cost => 5;

        public override int InitialDamage => 5;
        public override int InitialLife => 7;
        public override int InitialCost => 5;

        
        public override int BuffLife => 7;

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
