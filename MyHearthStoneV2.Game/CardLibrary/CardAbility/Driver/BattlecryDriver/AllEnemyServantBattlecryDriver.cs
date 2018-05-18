using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Capture;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.Event.Player;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.BattlecryDriver
{
    public class AllEnemyServantBattlecryDriver<G> : BaseBattlecryDriver<G, InParachuteFilter>, ICapture<InParachuteFilter, BattlecryEvent> where G : IGameAction
    {
        public override CastStyle CastStyle { get; set; } = CastStyle.敌方随从;
    }
}
