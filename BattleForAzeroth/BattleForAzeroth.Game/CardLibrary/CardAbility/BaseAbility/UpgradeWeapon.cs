using BattleForAzeroth.Game.Parameter;
using System.Linq;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.CardLibrary.Hero;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Number;
using System;
using BattleForAzeroth.Game.Event;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility
{
    /// <summary>
    /// 升级武器
    /// </summary>
    /// <typeparam name="TAG"></typeparam>
    /// <typeparam name="Damage">武器伤害</typeparam>
    /// <typeparam name="Durable">武器耐久</typeparam>
    public class UpgradeWeapon<TAG, Damage, Durable> : ICardAbility where TAG : IHeroFilter where Damage : INumber where Durable : INumber
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
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
