using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Widget.Filter.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.Widget.Filter.Servant;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter.Servant;
using BattleForAzeroth.Game.Widget.Filter.PickCard;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Neutral.Classical
{
    public class LeeroyJenkins : BaseServant
    {
        public override int Damage { get; set; }  = 6;
        public override int Life { get; set; }  = 2;
        public override int Cost { get; set; }  = 5;

        public override int InitialDamage => 6;
        public override int InitialLife => 2;
        public override int InitialCost => 5;


        public override int BuffLife { get; set; }  = 2;
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
