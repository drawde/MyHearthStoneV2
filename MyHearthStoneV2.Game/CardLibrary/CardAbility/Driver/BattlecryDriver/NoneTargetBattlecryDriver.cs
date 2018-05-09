using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Capture;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Event.Player;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.BattlecryDriver
{
    public class NoneTargetBattlecryDriver<G> : BaseBattlecryDriver<G, InParachuteFilter>, ICapture<InParachuteFilter, BattlecryEvent> where G : IGameAction
    {
        public override CastStyle CastStyle { get; set; } = CastStyle.无;
    }
}
