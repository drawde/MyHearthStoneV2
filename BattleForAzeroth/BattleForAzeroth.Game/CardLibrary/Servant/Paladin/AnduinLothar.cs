using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter.Servant;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using System.Collections.Generic;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Paladin
{
    public class AnduinLothar : BaseServant
    {
        public override int Damage { get; set; }  = 5;
        public override int Life { get; set; }  = 3;
        public override int Cost { get; set; }  = 10;

        public override int InitialDamage => 5;
        public override int InitialLife => 3;
        public override int InitialCost => 10;

        public override int BuffLife { get; set; }  = 3;
        public override string Describe => "亡语：使你场上、手牌、牌库的随从获得圣盾。";

        public override Rarity Rare => Rarity.史诗;

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new DeathWhisperDriver<HolyShield<AllPrimaryServantFilter>,NullFilter>(),
        };

        public override string Name => "安度因洛萨";
        public override Profession Profession => Profession.Paladin;
        public override string BackgroudImage => "Paladin/AnduinLothar.jpg";
    }
}
