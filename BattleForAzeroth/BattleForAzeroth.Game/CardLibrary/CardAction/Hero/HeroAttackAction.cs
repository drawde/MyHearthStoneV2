using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.CardLibrary.CardAction.Equip;
using BattleForAzeroth.Game.CardLibrary.Hero;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Parameter;


using System.Collections.Generic;
using System.Linq;

namespace BattleForAzeroth.Game.CardLibrary.CardAction.Hero
{
    /// <summary>
    /// 攻击一个随从或英雄
    /// </summary>
    public class HeroAttackAction : Action.IGameAction
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            ActionParameter para = actionParameter as ActionParameter;
            BaseHero baseHero = para.PrimaryCard as BaseHero;
            GameContext gameContext = para.GameContext;
            BaseBiology targetCard = para.SecondaryCard as BaseBiology;

            ActionParameter uaPara = new ActionParameter
            {
                PrimaryCard = targetCard,
                GameContext = actionParameter.GameContext,
                SecondaryCard = baseHero
            };
            

            if (baseHero.Equip != null)
            {
                baseHero.Equip.Durable -= 1;
            }
            CardActionFactory.CreateAction(targetCard, ActionType.受到攻击).Action(uaPara);
            //自己挨打（如果攻击的是英雄，则不掉血）
            if (targetCard.CardType == CardType.随从)
            {
                HeroUnderAttackAction underAttackAction = new HeroUnderAttackAction();
                ActionParameter underAttackPara = new ActionParameter()
                {
                    GameContext = gameContext,
                    PrimaryCard = baseHero,
                    SecondaryCard = targetCard,
                };
                underAttackAction.Action(underAttackPara);
            }

            baseHero.RemainAttackTimes -= 1;
            baseHero.CanAttack = baseHero.RemainAttackTimes > 0 ? true : false;
            return null;
        }
    }
}
