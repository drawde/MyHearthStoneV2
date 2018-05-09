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
            BaseServant baseServant = para.Servant;
            GameContext gameContext = para.GameContext;
            int damage = para.DamageOrHeal;

            //计算法术强度类技能
            var biologys = gameContext.DeskCards.GetDeskCardsByMyCard(baseServant);
            damage += biologys.Sum(c => c.SpellPower);
            if (biologys.Any(c => c.CardType == CardType.英雄 && (c as BaseHero).Equip != null))
            {
                damage += (biologys.First(c => c.CardType == CardType.英雄) as BaseHero).Equip.SpellPower;
            }

            var damagePara = CardActionFactory.CreateParameter(baseServant, actionParameter.GameContext, damage, secondaryCard: actionParameter.MainCard);
            CardActionFactory.CreateAction(baseServant, ActionType.受到伤害).Action(damagePara);
            return new IntParameter() { Value = damage };
        }
    }
}
