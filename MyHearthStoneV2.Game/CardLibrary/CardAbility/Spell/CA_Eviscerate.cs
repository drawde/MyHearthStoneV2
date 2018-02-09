using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Player;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Player;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Spell
{
    public class CA_Eviscerate : BaseCardAbility
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.法术;
        public override CastStyle CastStyle { get; set; } = CastStyle.敌方随从或英雄;
        public override CastCrosshairStyle CastCrosshairStyle { get; set; } = CastCrosshairStyle.单个;

        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            int damage = 2;
            if (actionParameter.GameContext.GetUserContextByMyCard(actionParameter.MainCard).ComboSwitch)
                damage = 4;

            BaseActionParameter para = CardActionFactory.CreateParameter(actionParameter.SecondaryCard, actionParameter.GameContext, damage, secondaryCard: actionParameter.MainCard);
            CardActionFactory.CreateAction(actionParameter.SecondaryCard, ActionType.受到法术伤害).Action(para);
            return null;
        }
    }
}
