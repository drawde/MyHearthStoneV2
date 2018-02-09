using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.Parameter.Controler;
using MyHearthStoneV2.Game.CardLibrary.Equip.Rogue;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Controler;
using MyHearthStoneV2.Game.Parameter.Equip;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Equip;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.HeroPower
{
    public class RogueAbility : BaseHeroAbility
    {
        public override string PowerImage { get; } = "Rogue.png";
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            BaseHero hero = actionParameter.GameContext.DeskCards.GetHeroByMyCard(actionParameter.MainCard as BaseBiology);
            ControlerActionParameter ctlPara = new ControlerActionParameter()
            {
                GameContext = actionParameter.GameContext,
                UserContext = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.MainCard)
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
    }
}
