using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter.Servant;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Paladin
{
    public class AnduinLothar : BaseServant
    {
        public override int Damage => 5;
        public override int Life => 3;
        public override int Cost => 10;

        public override int InitialDamage => 5;
        public override int InitialLife => 3;
        public override int InitialCost => 10;

        public override int BuffLife => 3;
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
