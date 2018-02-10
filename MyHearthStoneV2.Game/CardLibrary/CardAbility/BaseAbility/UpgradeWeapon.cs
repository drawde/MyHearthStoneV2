using MyHearthStoneV2.Game.Parameter;
using System.Linq;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Target;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    /// <summary>
    /// 升级武器
    /// </summary>
    /// <typeparam name="TAG"></typeparam>
    /// <typeparam name="Damage">武器伤害</typeparam>
    /// <typeparam name="Durable">武器耐久</typeparam>
    internal class UpgradeWeapon<TAG, Damage, Durable> : BaseCardAbility where TAG : IHeroTarget where Damage : IQuantity where Durable : IQuantity
    {
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            foreach (BaseBiology biology in actionParameter.GameContext.DeskCards.Where(GameActivator<TAG>.CreateInstance().Filter(actionParameter)))
            {
                BaseHero hero = biology as BaseHero;
                if (hero.Equip != null)
                {
                    hero.Equip.Damage += GameActivator<Damage>.CreateInstance().Quantity;
                    hero.Equip.Durable += GameActivator<Durable>.CreateInstance().Quantity;
                }
            }
            return null;
        }
    }
}
