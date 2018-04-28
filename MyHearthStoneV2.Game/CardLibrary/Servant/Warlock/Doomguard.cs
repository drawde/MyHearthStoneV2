using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Pick;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Warlock
{
    public class Doomguard : BaseServant
    {
        public override int Damage { get; set; } = 5;
        public override int Life { get; set; } = 7;
        public override int Cost { get; set; } = 5;

        public override int InitialDamage { get; set; } = 5;
        public override int InitialLife { get; set; } = 7;
        public override int InitialCost { get; set; } = 5;

        
        public override int BuffLife { get; set; } = 7;

        public override string Describe { get; set; } = "冲锋，战吼：随机弃2张牌。";

        public override Rarity Rare { get; set; } = Rarity.精良;

        public override List<ICardAbility> Abilities { get; set; } = new List<ICardAbility>()
        {            
            new NoneTargetBattlecryDriver<DoubleActionDriver<DropCard<MainUserContextFilter,Two,RandomPick>,Charge,NullFilter>,NullFilter>()
        };

        public override string BackgroudImage { get; set; } = "W11_141_D_1.png";

        public override string Name { get; set; } = "末日守卫";
        public override Profession Profession { get; set; } = Profession.Warlock;
        public override Race Race { get; set; } = Race.恶魔;
    }
}
