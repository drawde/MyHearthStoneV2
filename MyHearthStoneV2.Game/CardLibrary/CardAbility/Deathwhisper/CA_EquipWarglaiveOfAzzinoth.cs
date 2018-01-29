using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.Equip.Neutral.Classical;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Controler;
using MyHearthStoneV2.Game.Parameter.Controler;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Equip;
using MyHearthStoneV2.Game.Parameter.Equip;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Deathwhisper
{
    public class CA_EquipWarglaiveOfAzzinoth : BaseCardAbility
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.亡语;
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            BaseHero hero = actionParameter.GameContext.DeskCards.GetHeroByMyCard(actionParameter.MainCard as BaseBiology);
            ControlerActionParameter ctlPara = new ControlerActionParameter()
            {
                GameContext = actionParameter.GameContext,
                UserContext = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.MainCard)
            };

            WarglaiveOfAzzinoth warglaiveOfAzzinoth = new CreateNewCardInControllerAction<WarglaiveOfAzzinoth>().Action(ctlPara) as WarglaiveOfAzzinoth;
            EquipActionParameter para = new EquipActionParameter()
            {
                GameContext = actionParameter.GameContext,
                Equip = warglaiveOfAzzinoth,
                Hero = hero,                
            };
            new LoadAction().Action(para);
            //actionParameter.GameContext.AddActionStatement(new LoadEquipAction(), para);
            return null;
        }
    }
}
