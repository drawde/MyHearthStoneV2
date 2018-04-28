using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.CardLibrary.Filter.Servant;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class LeeroyJenkins : BaseServant
    {
        public override int Damage { get; set; } = 6;
        public override int Life { get; set; } = 2;
        public override int Cost { get; set; } = 5;

        public override int InitialDamage { get; set; } = 6;
        public override int InitialLife { get; set; } = 2;
        public override int InitialCost { get; set; } = 5;


        public override int BuffLife { get; set; } = 2;
        public override string Describe { get; set; } = "冲锋，战吼：为你的对手召唤2只1/1的雏龙。";

        public override Rarity Rare { get; set; } = Rarity.传说;

        public override List<ICardAbility> Abilities { get; set; } = new List<ICardAbility>()
        {
            new NoneTargetBattlecryDriver<DoubleActionDriver<Summon<SecondaryUserContextFilter,AssignServantFilter<Whelp>,Two>,Charge,NullFilter>,NullFilter>()
        };


        public override string Name { get; set; } = "火车王里诺艾";
        public override string BackgroudImage { get; set; } = "Classical/LeeroyJenkins.jpg";

        public override Profession Profession { get; set; } = Profession.Neutral;
    }
}
