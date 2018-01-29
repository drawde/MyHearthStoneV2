using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Equip;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Equip;
using MyHearthStoneV2.Game.Parameter.Hero;
using System.Collections.Generic;
using System.Linq;

namespace MyHearthStoneV2.Game.CardLibrary.CardAction.Hero
{
    /// <summary>
    /// 攻击一个随从或英雄
    /// </summary>
    internal class HeroAttackAction : IGameAction
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            HeroActionParameter para = actionParameter as HeroActionParameter;
            BaseHero baseHero = para.Biology;
            GameContext gameContext = para.GameContext;
            BaseBiology targetCard = para.SecondaryCard as BaseBiology;

            BaseActionParameter uaPara = CardActionFactory.CreateParameter(targetCard, actionParameter.GameContext, secondaryCard: baseHero);
            

            if (baseHero.Equip != null)
            {
                if (baseHero.Equip.Abilities.Any(c => c.SpellCardAbilityTimes.Any(x => x == SpellCardAbilityTime.英雄攻击)))
                {
                    gameContext.TriggerCardAbility(new List<Card> { baseHero.Equip }, SpellCardAbilityTime.英雄攻击, targetCard);
                }
                else
                {
                    CardActionFactory.CreateAction(targetCard, ActionType.受到攻击).Action(uaPara);
                }
                UnloadAction unloadAction = new UnloadAction();
                EquipActionParameter equipPara = new EquipActionParameter()
                {
                    GameContext = gameContext,
                    Equip = baseHero.Equip,
                };
                unloadAction.Action(equipPara);

                //baseHero.Equip.Unload(gameContext);
            }
            else
            {
                CardActionFactory.CreateAction(targetCard, ActionType.受到攻击).Action(uaPara);
            }

            //自己挨打（如果攻击的是英雄，则不掉血）
            if (targetCard.CardType == CardType.随从)
            {
                HeroUnderAttackAction underAttackAction = new HeroUnderAttackAction();
                HeroActionParameter underAttackPara = new HeroActionParameter()
                {
                    GameContext = gameContext,
                    Biology = baseHero,
                    SecondaryCard = targetCard,
                };
                underAttackAction.Action(underAttackPara);
            }
            //UnderAttack(baseHero, gameContext, targetCard);
            baseHero.RemainAttackTimes -= 1;
            baseHero.CanAttack = baseHero.RemainAttackTimes > 0 ? true : false;
            return null;
        }
    }
}
