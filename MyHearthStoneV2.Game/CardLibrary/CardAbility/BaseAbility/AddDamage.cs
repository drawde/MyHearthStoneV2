using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.Parameter;
using System.Linq;
namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    internal class AddDamage<TAG,Q> : BaseCardAbility where TAG : ITarget where Q : IQuantity
    {
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            foreach (BaseBiology biology in actionParameter.GameContext.DeskCards.Where(GameActivator<TAG>.CreateInstance().Filter(actionParameter)))
            {
                biology.Damage += GameActivator<Q>.CreateInstance().Quantity;
            }
            return null;
        }
    }
}
