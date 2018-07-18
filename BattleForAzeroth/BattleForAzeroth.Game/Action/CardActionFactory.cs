using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.CardLibrary.CardAction.Hero;
using BattleForAzeroth.Game.CardLibrary.CardAction.Servant;
using BattleForAzeroth.Game.CardLibrary.Hero;
using BattleForAzeroth.Game.CardLibrary.Servant;
using BattleForAzeroth.Game.Context;
namespace BattleForAzeroth.Game.Action
{
    /// <summary>
    /// 卡牌行为工厂类
    /// </summary>
    public class CardActionFactory
    {
        public static IGameAction CreateAction(Card biology, ActionType actionType)
        {
            IGameAction action = null;
            if (biology.CardType == CardType.英雄)
            {
                switch (actionType)
                {
                    case ActionType.受到伤害: action = new HeroByDamegeAction(); break;
                    case ActionType.受到攻击: action = new HeroUnderAttackAction(); break;
                    case ActionType.扣血: action = new DeductionHeroLifeAction(); break;
                    case ActionType.攻击: action = new HeroAttackAction(); break;
                    case ActionType.死亡: action = new HeroDeadAction(); break;
                    case ActionType.进场: action = new CastHeroAction(); break;
                    case ActionType.重置攻击次数: action = new ResetHeroRemainAttackTimesAction(); break;
                    case ActionType.受到治疗: action = new HeroByHealAction(); break;
                    case ActionType.受到法术伤害: action = new HeroBySpellAction(); break;
                }
            }
            else
            {
                switch (actionType)
                {
                    case ActionType.受到伤害: action = new ServantByDamegeAction(); break;
                    case ActionType.受到攻击: action = new ServantUnderAttackAction(); break;
                    case ActionType.扣血: action = new DeductionServantLifeAction(); break;
                    case ActionType.攻击: action = new ServantAttackAction(); break;
                    case ActionType.死亡: action = new ServantDeadAction(); break;
                    case ActionType.进场: action = new CastServantAction(); break;
                    case ActionType.重置攻击次数: action = new ResetServantRemainAttackTimes(); break;
                    case ActionType.受到治疗: action = new ServantByHealAction(); break;
                    case ActionType.受到法术伤害: action = new ServantBySpellAction(); break;
                }
            }
            return action;
        }
    }
}
