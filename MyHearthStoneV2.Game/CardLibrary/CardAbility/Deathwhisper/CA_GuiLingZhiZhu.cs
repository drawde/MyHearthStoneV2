using MyHearthStoneV2.Game.Controler;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.NAXX;
using System.Collections.Generic;
using System.Linq;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Deathwhisper
{
    public class CA_GuiLingZhiZhu : BaseCardAbility
    {
        public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.己方随从入坟场 };
        public override void CastAbility(GameContext gameContext, Card triggerCard, Card sourceCard, int targetCardIndex, int location)
        {
            var userContext = gameContext.Players.First(c => c.IsActivation);
            int count = 0;
            bool isActivation = gameContext.IsThisActivationUserCard(sourceCard);
            while (userContext.DeskCards.Any(c => c == null) && count < 2)
            {
                gameContext.CreateNewCardInDesk<XiaoZhiZhu>(isActivation);
                count++;
            }
        }
    }
}
