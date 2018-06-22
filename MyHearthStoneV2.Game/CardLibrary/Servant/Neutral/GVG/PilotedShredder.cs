using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.Widget.Filter.Context;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Widget.Filter.Servant;
using System.Collections.Generic;
using MyHearthStoneV2.Game.Widget.Filter.PickCard;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.GVG
{
    public class PilotedShredder : BaseServant
    {
        public override int Damage { get; set; }  = 4;
        public override int Life { get; set; }  = 3;
        public override int Cost { get; set; }  = 4;

        public override int InitialDamage => 4;
        public override int InitialLife => 3;
        public override int InitialCost => 4;
        
        public override int BuffLife { get; set; }  = 3;

        public override string Describe => "亡语：增加召唤一个法力值消耗为（2）点的随从。";

        public override Rarity Rare => Rarity.精良;

        public override List<ICardAbility> Abilities => new List<ICardAbility>() {
            new DeathWhisperDriver<Summon<PrimaryUserContextFilter,NullFilter,RandomServantOfCostFilter<Two>,AllPickFilter,ONE>, InDeskFilter>()
        };

        public override string BackgroudImage => "GVG/PilotedShredder.jpg";

        public override string Name => "载人收割机";
        public override Profession Profession => Profession.Neutral;
        public override Race Race => Race.机械;

    }
}
