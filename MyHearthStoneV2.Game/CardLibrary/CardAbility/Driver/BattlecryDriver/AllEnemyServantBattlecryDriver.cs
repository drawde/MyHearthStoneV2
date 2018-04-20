using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Capture;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.Event.Player;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.BattlecryDriver
{
    public class AllEnemyServantBattlecryDriver<G, F> : BaseDriver<G, F>, ICapture<F, CastServantEvent> where G : IGameAction where F : ICardLocationFilter
    {
        public override CastStyle CastStyle { get; set; } = CastStyle.敌方随从;
    }
}
