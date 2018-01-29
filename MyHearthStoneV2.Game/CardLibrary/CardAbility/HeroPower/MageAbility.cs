using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Hero;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Hero;
using MyHearthStoneV2.Game.Action;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.HeroPower
{
    public class MageAbility : BaseHeroAbility
    {
        public override string PowerImage { get; } = "Mage.png";
        public override CastCrosshairStyle CastCrosshairStyle { get; } = CastCrosshairStyle.单个;
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            var uc = actionParameter.GameContext.GetActivationUserContext();
            var hero = actionParameter.MainCard as BaseHero;

            BaseActionParameter para = CardActionFactory.CreateParameter(actionParameter.SecondaryCard, actionParameter.GameContext, 1, secondaryCard: hero);
            CardActionFactory.CreateAction(actionParameter.SecondaryCard, ActionType.受到伤害).Action(para);
            //hero.BiologyByDamege(actionParameter.SecondaryCard, actionParameter.GameContext, 1);
            return null;
        }
    }
}
