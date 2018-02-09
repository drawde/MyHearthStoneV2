using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Context;
namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.WarCry
{
    public class CA_SI7Agent : BaseCardAbility
    {
        public override CastCrosshairStyle CastCrosshairStyle { get; set; } = CastCrosshairStyle.单个;

        public override AbilityType AbilityType { get; set; } = AbilityType.战吼;
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            var user = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.MainCard);
            if (user.ComboSwitch)
            {
                BaseBiology biology = actionParameter.SecondaryCard as BaseBiology;
                var para = CardActionFactory.CreateParameter(biology, actionParameter.GameContext, 2, secondaryCard: actionParameter.MainCard);
                CardActionFactory.CreateAction(biology, ActionType.受到伤害).Action(para);
            }
            return null;
        }
    }
}
