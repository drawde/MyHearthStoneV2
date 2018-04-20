using System.Collections.Generic;
using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.CardAction;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Observer
{
    public class CA_Patchwerk : IBaseCardAbility
    {
        public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get;  set; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.随从攻击 };
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            BaseServant servant = actionParameter.MainCard as BaseServant;
            if (actionParameter.SecondaryCard.CardType == CardType.英雄)
            {
                BaseHero hero = actionParameter.SecondaryCard as BaseHero;
                //将护甲削减为0
                int ammo = hero.Ammo;
                hero.Ammo = 0;
                BaseActionParameter para = CardActionFactory.CreateParameter(hero, actionParameter.GameContext, servant.Damage * 2, secondaryCard: actionParameter.MainCard);
                CardActionFactory.CreateAction(hero, ActionType.受到伤害).Action(para);
                //hero.BiologyByDamege(actionParameter.SecondaryCard, actionParameter.GameContext, servant.Damage * 2);
                hero.Ammo = ammo;
            }
            else
            {
                BaseActionParameter para = CardActionFactory.CreateParameter(actionParameter.SecondaryCard, actionParameter.GameContext, secondaryCard: actionParameter.MainCard);
                CardActionFactory.CreateAction(actionParameter.SecondaryCard, ActionType.受到攻击).Action(para);
                //targetServant.UnderAttack(actionParameter.GameContext, servant);
            }
            return null;
        }
    }
}
