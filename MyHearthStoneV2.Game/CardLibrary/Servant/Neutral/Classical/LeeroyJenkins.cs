using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Widget.Filter.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.Widget.Filter.Servant;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter.Servant;
using MyHearthStoneV2.Game.Widget.Filter.PickCard;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class LeeroyJenkins : BaseServant
    {
        public override int Damage => 6;
        public override int Life => 2;
        public override int Cost => 5;

        public override int InitialDamage => 6;
        public override int InitialLife => 2;
        public override int InitialCost => 5;


        public override int BuffLife => 2;
        public override string Describe => "冲锋，战吼：为你的对手召唤2只1/1的雏龙。";

        public override Rarity Rare => Rarity.传说;

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new NoneTargetBattlecryDriver
            <
                Summon<SecondaryUserContextFilter,NullFilter,AssignServantFilter<Whelp>,AllPickFilter,Two>
            >()
        };

        public override bool HasCharge => true;
        public override string Name => "火车王里诺艾";
        public override string BackgroudImage => "Classical/LeeroyJenkins.jpg";

        public override Profession Profession => Profession.Neutral;
    }
}
