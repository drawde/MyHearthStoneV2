using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using System.Linq;
namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    internal class Heal<TAG, C> : BaseCardAbility where TAG : IFilter where C : IQuantity
    {
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            TAG tag = GameActivator<TAG>.CreateInstance();
            C qat = GameActivator<C>.CreateInstance();

            foreach (BaseBiology biology in actionParameter.GameContext.DeskCards.Where(tag.Filter(actionParameter)).OrderBy(c => c.CastIndex))
            {
                var para = CardActionFactory.CreateParameter(biology, actionParameter.GameContext, qat.Quantity, secondaryCard: actionParameter.MainCard);
                CardActionFactory.CreateAction(biology, ActionType.受到治疗).Action(para);
            }
            return null;
        }
    }
}
