using BattleForAzeroth.Game.CardLibrary.CardAction.Controler;
using BattleForAzeroth.Game.CardLibrary.CardAction.Equip;
using BattleForAzeroth.Game.CardLibrary.Equip;
using BattleForAzeroth.Game.CardLibrary.Hero;
using BattleForAzeroth.Game.Parameter;

using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Event;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility
{
    /// <summary>
    /// 装备一件武器
    /// </summary>
    /// <typeparam name="E"></typeparam>
    public class LoadEquip<E> : ICardAbility where E : BaseEquip
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            BaseHero hero = actionParameter.GameContext.DeskCards.GetHeroByMyCard(actionParameter.PrimaryCard as BaseBiology);
            var ctlPara = new ActionParameter()
            {
                GameContext = actionParameter.GameContext,
                UserContext = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.PrimaryCard)
            };

            E equip = new CreateNewCardInControllerAction<E>().Action(ctlPara) as E;
            var para = new ActionParameter()
            {
                GameContext = actionParameter.GameContext,
                Equip = equip,
                Hero = hero,
            };
            new LoadAction().Action(para);
            return null;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
