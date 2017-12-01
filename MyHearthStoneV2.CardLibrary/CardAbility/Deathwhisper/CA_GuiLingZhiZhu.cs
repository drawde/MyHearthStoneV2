
using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.Context;
using MyHearthStoneV2.CardLibrary.Servant;
using MyHearthStoneV2.CardLibrary.Servant.Neutral.NAXX;
using MyHearthStoneV2.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.CardAbility.Deathwhisper
{
    public class CA_GuiLingZhiZhu : BaseCardAbility
    {
        public override List<SpellCardAbilityTime> LstSpellCardAbilityTime { get; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.己方随从入坟场 };
        public override void CastAbility(GameContext gameContext, Card triggerCard, Card sourceCard, List<int> targetCardIndex, int location)
        {
            var userContext = gameContext.Players.First(c => c.IsActivation);
            int count = 0;
            bool isActivation = gameContext.IsThisActivationUserCard(sourceCard);
            while (userContext.DeskCards.Any(c => c is null) && count < 2)
            {
                gameContext.CreateNewCardInDesk<XiaoZhiZhu>(isActivation);
                count++;
            }
        }
    }
}
