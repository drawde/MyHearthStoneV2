using BattleForAzeroth.Game.CardLibrary.Servant;
using BattleForAzeroth.Game.Parameter;

namespace BattleForAzeroth.Game.CardLibrary.CardAction.Servant
{
    /// <summary>
    /// 重置随从攻击次数
    /// </summary>
    public class ResetServantRemainAttackTimes : Action.IGameAction
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            BaseServant servant = actionParameter.PrimaryCard as BaseServant;

            if (servant.Damage > 0 && servant.CanAttack && servant.RemainAttackTimes < 1)
            {
                servant.RemainAttackTimes += 1;
            }
            return null;
        }
    }
}
