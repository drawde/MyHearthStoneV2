using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.Capture;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.Event.Player;
namespace BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.BattlecryDriver
{
    public class AllServantBattlecryDriver<G> : BaseBattlecryDriver<G, InParachuteFilter>, ICapture<InParachuteFilter, BattlecryEvent> where G : IGameAction
    {
        public override CastStyle CastStyle { get; set; } = CastStyle.随从;
    }
}
