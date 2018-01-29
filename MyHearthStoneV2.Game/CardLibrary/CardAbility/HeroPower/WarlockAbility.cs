using MyHearthStoneV2.Game.CardLibrary.CardAction.Player;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Controler;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Player;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.HeroPower
{
    internal class WarlockAbility : BaseHeroAbility
    {
        public override string PowerImage { get; } = "Warlock.png";
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            var uc = actionParameter.GameContext.GetActivationUserContext();
            var hero = actionParameter.GameContext.DeskCards.GetHeroByIsFirst(uc.IsFirst);
            hero.Life -= 2;
            DrawCardActionParameter para = new DrawCardActionParameter()
            {
                DrawCount = 1,
                GameContext = actionParameter.GameContext,
                UserContext = uc
            };
            new DrawCardAction().Action(para);
            //actionParameter.GameContext.DrawCard();
            return null;
        }
    }
}
