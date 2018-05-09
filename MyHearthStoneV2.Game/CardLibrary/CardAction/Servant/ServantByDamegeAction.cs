using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Servant;
using System.Collections.Generic;
using System.Linq;
namespace MyHearthStoneV2.Game.CardLibrary.CardAction.Servant
{
    /// <summary>
    /// 随从受到伤害（被火球砸、火冲点）
    /// </summary>
    public class ServantByDamegeAction : Action.IGameAction
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            ServantActionParameter para = actionParameter as ServantActionParameter;
            BaseServant servant = para.Servant;
            GameContext gameContext = para.GameContext;
            Card triggerCard = para.SecondaryCard;
            int damege = para.DamageOrHeal;

            DeductionServantLifeAction dslAct = new DeductionServantLifeAction();
            ServantActionParameter dslPara = new ServantActionParameter()
            {
                GameContext = gameContext,
                Servant = servant,
                SecondaryCard = triggerCard,
                DamageOrHeal = damege,
            };
            dslAct.Action(dslPara);

            return null;
        }
    }
}
