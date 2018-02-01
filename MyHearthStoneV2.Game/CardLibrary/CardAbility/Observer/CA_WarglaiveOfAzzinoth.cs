using MyHearthStoneV2.Game.Context;
using System.Collections.Generic;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Equip;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.CardLibrary.Equip;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Parameter.Equip;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.Parameter.CardAbility;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Observer
{
    public class CA_WarglaiveOfAzzinoth : BaseCardAbility
    {
        public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get; set; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.英雄攻击 };
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            BaseEquip equip = actionParameter.MainCard as BaseEquip;
            BaseHero baseHero = actionParameter.GameContext.DeskCards.GetHeroByIsFirst(actionParameter.GameContext.GetUserContextByMyCard(actionParameter.MainCard).IsFirst);
            

            if (actionParameter.SecondaryCard.CardType == CardType.英雄)
            {
                BaseHero hero = actionParameter.SecondaryCard as BaseHero;
                //将护甲削减为0
                int ammo = hero.Ammo;
                hero.Ammo = 0;
                BaseActionParameter para = CardActionFactory.CreateParameter(hero, actionParameter.GameContext, equip.Damage + baseHero.Damage, secondaryCard: actionParameter.MainCard);
                CardActionFactory.CreateAction(hero, ActionType.受到伤害).Action(para);
                //hero.BiologyByDamege(actionParameter.SecondaryCard, actionParameter.GameContext, equip.Damege + baseHero.Damage);
                hero.Ammo = ammo;
            }
            else
            {
                //沉默目标
                Silence silence = new Silence();
                silence.Action(actionParameter);
                //actionParameter.GameContext.DisableCardAbility(new List<BaseBiology>() { actionParameter.SecondaryCard as BaseBiology });

                BaseActionParameter para = CardActionFactory.CreateParameter(actionParameter.SecondaryCard, actionParameter.GameContext, secondaryCard: actionParameter.MainCard);
                CardActionFactory.CreateAction(actionParameter.SecondaryCard, ActionType.受到攻击).Action(para);

                //BaseServant servant = actionParameter.SecondaryCard as BaseServant;
                //servant.UnderAttack(actionParameter.GameContext, baseHero);
            }

            UnloadAction unloadAction = new UnloadAction();
            unloadAction.Action(new EquipActionParameter()
            {
                Equip = actionParameter.MainCard as BaseEquip,
                GameContext = actionParameter.GameContext
            });

            //baseHero.Equip.Unload(actionParameter.GameContext);
            return null;
        }
    }
}
