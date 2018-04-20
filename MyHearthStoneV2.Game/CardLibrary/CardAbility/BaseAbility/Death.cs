using MyHearthStoneV2.Common;
using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.Parameter;
using System.Linq;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    /// <summary>
    /// 将一个目标标记为死亡
    /// </summary>
    /// <typeparam name="TAG"></typeparam>
    public class Death<TAG> : IBaseCardAbility where TAG : IFilter
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            TAG tag = GameActivator<TAG>.CreateInstance();
            foreach (var card in actionParameter.GameContext.DeskCards.Where(tag.Filter(actionParameter)).OrderBy(c => c.CastIndex))
            {
                BaseBiology biology = card as BaseBiology;
                biology.Deathing = true;
                BaseActionParameter para = CardActionFactory.CreateParameter(biology, actionParameter.GameContext);
                CardActionFactory.CreateAction(biology, ActionType.死亡).Action(para);
            }
            return null;
        }
    }
}
