using MyHearthStoneV2.Game.Parameter;
using System.Linq;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
using System;
using MyHearthStoneV2.Game.Event;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    /// <summary>
    /// 升级武器
    /// </summary>
    /// <typeparam name="TAG"></typeparam>
    /// <typeparam name="Damage">武器伤害</typeparam>
    /// <typeparam name="Durable">武器耐久</typeparam>
    public class UpgradeWeapon<TAG, Damage, Durable> : ICardAbility where TAG : IHeroFilter where Damage : INumber where Durable : INumber
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            foreach (BaseBiology biology in actionParameter.GameContext.DeskCards.Where(Activator.CreateInstance<TAG>().Filter(actionParameter)))
            {
                BaseHero hero = biology as BaseHero;
                if (hero.Equip != null)
                {
                    hero.Equip.Damage += GameActivator<Damage>.CreateInstance().GetNumber(actionParameter);
                    hero.Equip.Durable += GameActivator<Durable>.CreateInstance().GetNumber(actionParameter);
                }
            }
            return null;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
