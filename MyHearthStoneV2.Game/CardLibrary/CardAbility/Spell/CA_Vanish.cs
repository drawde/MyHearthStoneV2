using MyHearthStoneV2.Game.CardLibrary.CardAction.Player;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Player;
using System.Linq;
namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Spell
{
    public class CA_Vanish : BaseCardAbility
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.法术;

        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            GameContext gameContext = actionParameter.GameContext;
            foreach (BaseBiology bio in gameContext.DeskCards.GetServants())
            {
                UserContext user = actionParameter.GameContext.GetUserContextByMyCard(bio);
                ReturnCardToHandParameter para = new ReturnCardToHandParameter()
                {
                    ReturnCount = 1,
                    GameContext = actionParameter.GameContext,
                    UserContext = user,
                    MainCard = bio
                };
                new ReturnCardToHandAction().Action(para);
            }
            return null;
        }
    }
}
