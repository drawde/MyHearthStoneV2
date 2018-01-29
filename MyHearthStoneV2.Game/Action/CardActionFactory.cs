using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Hero;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Servant;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter.Biology;
using MyHearthStoneV2.Game.Parameter.Hero;
using MyHearthStoneV2.Game.Parameter.Servant;

namespace MyHearthStoneV2.Game.Action
{
    /// <summary>
    /// 卡牌行为工厂类
    /// </summary>
    internal class CardActionFactory
    {
        internal static IGameAction CreateAction(Card biology, ActionType actionType)
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
                }
            }
            return action;
        }

        internal static BiologyActionParameter CreateParameter(Card biology, GameContext gameContext, int damage = 0, int deskIndex = -1, Card mainCard = null, Card secondaryCard = null)
        {
            BiologyActionParameter para = null;
            if (biology.CardType == CardType.英雄)
            {
                para = new HeroActionParameter
                {
                    Biology = biology as BaseHero,
                    GameContext = gameContext,
                    MainCard = mainCard,
                    SecondaryCard = secondaryCard,
                    Damage = damage,
                    DeskIndex = deskIndex
                };
            }
            else
            {
                para = new ServantActionParameter
                {
                    Biology = biology as BaseServant,
                    GameContext = gameContext,
                    MainCard = mainCard,
                    SecondaryCard = secondaryCard,
                    Damage = damage,
                    DeskIndex = deskIndex
                };
            }
            return para;
        }
    }
}
