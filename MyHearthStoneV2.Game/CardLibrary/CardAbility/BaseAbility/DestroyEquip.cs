using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Parameter;
using System;
using System.Linq;
namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    /// <summary>
    /// 摧毁武器
    /// </summary>
    /// <typeparam name="TAG"></typeparam>
    public class DestroyEquip<TAG> : ICardAbility where TAG : IHeroFilter
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            foreach (BaseBiology biology in actionParameter.GameContext.DeskCards.Where(Activator.CreateInstance<TAG>().Filter(actionParameter)))
            {
                BaseHero hero = biology as BaseHero;
                if (hero.Equip != null)
                {
                    hero.Equip.Durable = 0;
                }
            }
            return null;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
