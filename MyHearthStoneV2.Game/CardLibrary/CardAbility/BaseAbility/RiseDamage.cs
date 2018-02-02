using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Context;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    public class RiseDamage : BaseCardAbility
    {
        public override CastStyle CastStyle { get; set; } = CastStyle.随从;
        public override CastCrosshairStyle CastCrosshairStyle { get; set; } = CastCrosshairStyle.单个;

        public override AbilityType AbilityType { get; set; } = AbilityType.战吼;
        public virtual int Damage { get; set; } = 1;
        
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            BaseBiology biology = actionParameter.SecondaryCard as BaseBiology;
            if (biology == null)
            {
                if (CastStyle == CastStyle.己方英雄)
                {
                    biology = actionParameter.GameContext.DeskCards.GetHeroByIsFirst(actionParameter.GameContext.GetUserContextByMyCard(actionParameter.MainCard).IsFirst);
                }
                else if (CastStyle == CastStyle.敌方英雄)
                {
                    biology = actionParameter.GameContext.DeskCards.GetHeroByIsFirst(actionParameter.GameContext.GetUserContextByEnemyCard(actionParameter.MainCard).IsFirst);
                }
            }
            var para = CardActionFactory.CreateParameter(biology, actionParameter.GameContext, Damage, secondaryCard: actionParameter.MainCard);
            CardActionFactory.CreateAction(biology, ActionType.受到伤害).Action(para);
            return null;
        }
    }
}
