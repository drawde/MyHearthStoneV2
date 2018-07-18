using BattleForAzeroth.Game.Parameter;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.CardLibrary.Hero;
using BattleForAzeroth.Game.CardLibrary.Equip.Rogue;
using BattleForAzeroth.Game.CardLibrary.CardAction.Controler;
using BattleForAzeroth.Game.CardLibrary.CardAction.Equip;
using BattleForAzeroth.Game.CardLibrary.CardAbility.AbilityAttribute;
using BattleForAzeroth.Game.Event;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.HeroPower
{
    public class RogueAbility : DefaultAttribute, IHeroAbility
    {
        public string PowerImage { get; } = "Rogue.png";
        public int Cost { get; set; } = 2;
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            BaseHero hero = actionParameter.GameContext.DeskCards.GetHeroByMyCard(actionParameter.PrimaryCard as BaseBiology);
            var ctlPara = new ActionParameter()
            {
                GameContext = actionParameter.GameContext,
                UserContext = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.PrimaryCard)
            };

            WickedKnife knife = new CreateNewCardInControllerAction<WickedKnife>().Action(ctlPara) as WickedKnife;
            var para = new ActionParameter()
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
