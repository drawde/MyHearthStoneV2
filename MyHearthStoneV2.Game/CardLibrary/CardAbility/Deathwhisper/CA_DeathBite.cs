using MyHearthStoneV2.Game.CardLibrary.Spell.Warrior;
using System.Linq;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Controler;
using MyHearthStoneV2.Game.Parameter.Controler;
using MyHearthStoneV2.Game.Context;
namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Deathwhisper
{
    public class CA_DeathBite : BaseCardAbility
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.亡语;
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            ControlerActionParameter para = new ControlerActionParameter()
            {
                GameContext = actionParameter.GameContext,
                UserContext = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.MainCard)
            };
            Whirlwind ww = new CreateNewCardInControllerAction<Whirlwind>().Action(para) as Whirlwind;
            para = new ControlerActionParameter()
            {
                GameContext = actionParameter.GameContext,
                MainCard = ww,                
            };
            ww.Abilities.First().Action(para);
            //actionParameter.GameContext.AddActionStatement(ww.Abilities.First(), para);
            return null;
        }
    }
}
