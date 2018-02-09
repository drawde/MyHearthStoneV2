using MyHearthStoneV2.Game.CardLibrary.CardAction.Player;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Player;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Spell
{
    public class CA_Sap : BaseCardAbility
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.法术;
        public override CastStyle CastStyle { get; set; } = CastStyle.敌方随从;
        public override CastCrosshairStyle CastCrosshairStyle { get; set; } = CastCrosshairStyle.单个;

        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            UserContext user = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.SecondaryCard);            
            ReturnCardToHandParameter para = new ReturnCardToHandParameter()
            {
                ReturnCount = 1,
                GameContext = actionParameter.GameContext,
                UserContext = user,
                MainCard = actionParameter.SecondaryCard
            };
            new ReturnCardToHandAction().Action(para);
            return null;
        }
    }
}
