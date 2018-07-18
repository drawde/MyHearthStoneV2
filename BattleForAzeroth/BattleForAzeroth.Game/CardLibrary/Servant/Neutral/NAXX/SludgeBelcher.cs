using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.Widget.Filter.Context;
using BattleForAzeroth.Game.Widget.Filter.PickCard;
using BattleForAzeroth.Game.Widget.Filter.Servant;
using BattleForAzeroth.Game.Widget.Number;
using System.Collections.Generic;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Neutral.NAXX
{
    public class SludgeBelcher : BaseServant
    {
        public override int Damage { get; set; }  = 3;
        public override int Life { get; set; }  = 5;
        public override int Cost { get; set; }  = 5;

        public override int InitialDamage => 3;
        public override int InitialLife => 5;
        public override int InitialCost => 5;

        public override int BuffLife { get; set; }  = 5;

        public override string Describe => "嘲讽，亡语：召唤一个1/2并具有嘲讽的泥浆怪。";

        public override Rarity Rare => Rarity.精良;

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new DeathWhisperDriver<Summon<PrimaryUserContextFilter,NullFilter,AssignServantFilter<Slime>,AllPickFilter,ONE>,InDeskFilter>()
        };
        public override bool HasTaunt => true;
        public override string BackgroudImage => "NAXX/SludgeBelcher.png";

        public override string Name => "淤泥喷射者";
        public override bool CanAttack => false;
        public override Profession Profession => Profession.Neutral;
    }
}
