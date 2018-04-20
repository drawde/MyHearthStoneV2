using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Servant;
using MyHearthStoneV2.Game.Parameter.Variable;
using System.Linq;


namespace MyHearthStoneV2.Game.CardLibrary.CardAction.Servant
{
    /// <summary>
    /// 随从受到法术伤害
    /// </summary>
    public class ServantBySpellAction : Action.IGameAction
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            ServantActionParameter para = actionParameter as ServantActionParameter;
            BaseServant baseServant = para.Biology;
            GameContext gameContext = para.GameContext;
            int damage = para.DamageOrHeal;

            var biologys = gameContext.DeskCards.GetDeskCardsByMyCard(baseServant);
            //计算法术强度类技能
            foreach (var biology in biologys.Where(c => c != null))
            {
                if (biology.Abilities.Any(c => c.AbilityType == AbilityType.法术强度))
                {
                    damage += biology.Abilities.Where(c => c.AbilityType == AbilityType.法术强度).Sum(x => (x as SpellPower).Damage);
                }
                if (biology.CardType == CardType.英雄)
                {
                    BaseHero hero = biology as BaseHero;
                    if (hero.Equip != null && hero.Equip.Abilities.Any(c => c.AbilityType == AbilityType.法术强度))
                    {
                        damage += hero.Equip.Abilities.Where(c => c.AbilityType == AbilityType.法术强度).Sum(x => (x as SpellPower).Damage);
                    }
                }
            }

            var damagePara = CardActionFactory.CreateParameter(baseServant, actionParameter.GameContext, damage, secondaryCard: actionParameter.MainCard);
            CardActionFactory.CreateAction(baseServant, ActionType.受到伤害).Action(damagePara);
            return new IntParameter() { Value = damage };
        }
    }
}
