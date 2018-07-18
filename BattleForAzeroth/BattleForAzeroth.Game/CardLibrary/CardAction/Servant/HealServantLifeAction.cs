using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.CardLibrary.Servant;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Parameter;


namespace BattleForAzeroth.Game.CardLibrary.CardAction.Servant
{
    /// <summary>
    /// 随从受到治疗时，增加它的生命值，然后触发随从或英雄治疗后的技能
    /// </summary>
    public class HealServantLifeAction : Action.IGameAction
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {           
            BaseServant servant = actionParameter.PrimaryCard as BaseServant;
            GameContext gameContext = actionParameter.GameContext;
            Card triggerCard = actionParameter.SecondaryCard;

            servant.Life += actionParameter.DamageOrHeal;
            if (servant.Life > servant.BuffLife)
            {
                servant.Life = servant.BuffLife;
            }
            return null;
        }
    }
}
