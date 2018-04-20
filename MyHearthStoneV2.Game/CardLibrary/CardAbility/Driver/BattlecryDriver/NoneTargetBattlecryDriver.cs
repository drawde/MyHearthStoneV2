using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Capture;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Event.Player;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.BattlecryDriver
{
    public class NoneTargetBattlecryDriver<G, F> : BaseBattlecryDriver<G, F>, ICapture<F, CastServantEvent> where G : IGameAction where F : ICardLocationFilter
    {
        
    }
}
