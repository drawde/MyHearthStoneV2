using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter.Servant;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class Doomsayer : BaseServant
    {
        public override int Damage { get; set; }  = 0;
        public override int Life { get; set; }  = 7;
        public override int Cost { get; set; }  = 2;

        public override int InitialDamage => 0;
        public override int InitialLife => 7;
        public override int InitialCost => 2;

        public override int BuffLife { get; set; }  = 7;

        public override string Describe => "在你的回合开始时，消灭所有随从。";

        public override Rarity Rare => Rarity.史诗;

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new MyTurnStartDriver<Death<AllServantFilter>,NullFilter>()            
        };

        public override string BackgroudImage => "Classical/Doomsayer.jpg";

        public override string Name => "末日预言者";
        public override Profession Profession => Profession.Neutral;
    }
}
