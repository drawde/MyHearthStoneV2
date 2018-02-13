using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using System.Linq;
namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Spell
{
    internal class AppendPower<UC, Q> : BaseCardAbility where UC : IUserContextFilter where Q : IQuantity
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.法术;
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            UC uc = GameActivator<UC>.CreateInstance();
            var users = actionParameter.GameContext.Players.Where(uc.Filter(actionParameter));
            foreach (UserContext user in users)
            {
                user.Power += GameActivator<Q>.CreateInstance().Quantity;
            }
            return null;
        }
    }
}
