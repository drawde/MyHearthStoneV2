using BattleForAzeroth.Game.CardLibrary.Servant;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Parameter;
namespace BattleForAzeroth.Game.CardLibrary.CardAction.Servant
{
    /// <summary>
    /// 随从受到治疗
    /// </summary>
    public class ServantByHealAction : Action.IGameAction
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {            
            BaseServant servant = actionParameter.PrimaryCard as BaseServant;
            GameContext gameContext = actionParameter.GameContext;
            Card triggerCard = actionParameter.SecondaryCard;
            int damege = actionParameter.DamageOrHeal;

            DeductionServantLifeAction dslAct = new DeductionServantLifeAction();
            var dslPara = new ActionParameter()
            {
                GameContext = gameContext,
                PrimaryCard = servant,
                SecondaryCard = triggerCard,
                DamageOrHeal = damege,
            };
            dslAct.Action(dslPara);

            return null;
        }
    }
}
