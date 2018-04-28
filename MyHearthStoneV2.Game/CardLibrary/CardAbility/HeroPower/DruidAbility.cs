using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.AbilityAttribute;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Controler;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Parameter;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.HeroPower
{
    public class DruidAbility : DefaultAttribute, IHeroAbility
    {
        public string PowerImage { get; } = "Druid.png";
        public int Cost { get; set; } = 2;
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            var uc = actionParameter.GameContext.GetActivationUserContext();
            var hero = actionParameter.GameContext.DeskCards.GetHeroByIsFirst(uc.IsFirst);
            hero.Ammo += 1;
            hero.Damage += 1;
            BaseActionParameter para = CardActionFactory.CreateParameter(actionParameter.MainCard, actionParameter.GameContext);
            CardActionFactory.CreateAction(actionParameter.MainCard, ActionType.重置攻击次数).Action(para);

            return null;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
