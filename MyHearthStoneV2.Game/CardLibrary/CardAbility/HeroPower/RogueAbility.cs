using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.Parameter.Controler;
using MyHearthStoneV2.Game.CardLibrary.Equip.Rogue;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Controler;
using MyHearthStoneV2.Game.Parameter.Equip;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Equip;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.AbilityAttribute;
using MyHearthStoneV2.Game.Event;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.HeroPower
{
    public class RogueAbility : DefaultAttribute, IHeroAbility
    {
        public string PowerImage { get; } = "Rogue.png";
        public int Cost { get; set; } = 2;
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            BaseHero hero = actionParameter.GameContext.DeskCards.GetHeroByMyCard(actionParameter.PrimaryCard as BaseBiology);
            ControlerActionParameter ctlPara = new ControlerActionParameter()
            {
                GameContext = actionParameter.GameContext,
                UserContext = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.PrimaryCard)
            };

            WickedKnife knife = new CreateNewCardInControllerAction<WickedKnife>().Action(ctlPara) as WickedKnife;
            EquipActionParameter para = new EquipActionParameter()
            {
                GameContext = actionParameter.GameContext,
                Equip = knife,
                Hero = hero,
            };
            new LoadAction().Action(para);
            
            return null;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
