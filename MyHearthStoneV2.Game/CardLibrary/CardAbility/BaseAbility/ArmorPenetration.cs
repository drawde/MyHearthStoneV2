using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Parameter;
using System;
using System.Linq;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    public class ArmorPenetration<Hero, Q> : ICardAbility where Hero : IHeroFilter where Q : INumber
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            Hero heroFilter = Activator.CreateInstance<Hero>();
            Q damege = GameActivator<Q>.CreateInstance();

            var heros = actionParameter.GameContext.DeskCards.Where(heroFilter.Filter(actionParameter));
            foreach (Card card in heros)
            {
                BaseHero hero = card as BaseHero;
                //将护甲削减为0
                int ammo = hero.Ammo;
                hero.Ammo = 0;
                BaseActionParameter para = CardActionFactory.CreateParameter(hero, actionParameter.GameContext, damege.GetNumber(actionParameter), secondaryCard: actionParameter.PrimaryCard);
                CardActionFactory.CreateAction(hero, ActionType.受到伤害).Action(para);
                //hero.BiologyByDamege(actionParameter.SecondaryCard, actionParameter.GameContext, servant.Damage * 2);
                hero.Ammo = ammo;
            }
            return null;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
