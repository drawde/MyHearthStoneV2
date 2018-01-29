using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Hero;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.CardAbility;
using MyHearthStoneV2.Game.Parameter.Hero;
using MyHearthStoneV2.Game.Parameter.Servant;
using System.Linq;

namespace MyHearthStoneV2.Game.CardLibrary.CardAction.Servant
{
    /// <summary>
    /// 随从被攻击
    /// </summary>
    internal class ServantUnderAttackAction : IGameAction
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            ServantActionParameter para = actionParameter as ServantActionParameter;
            BaseServant servant = para.Biology;
            GameContext gameContext = para.GameContext;
            BaseBiology attackCard = para.SecondaryCard as BaseBiology;
            int damege = para.Damage;

            if (attackCard.Abilities.Any(c => c.SpellCardAbilityTimes.Any(x => x == SpellCardAbilityTime.随从攻击)))
            {
                var abiliti = attackCard.Abilities.First(c => c.SpellCardAbilityTimes.Any(x => x == SpellCardAbilityTime.随从攻击));
                CardAbilityParameter actionPara = new CardAbilityParameter()
                {
                    GameContext = gameContext,
                    MainCard = servant,
                    SecondaryCard = attackCard,
                };
                abiliti.Action(para);
            }
            else
            {
                int trueDamege = attackCard.Damage;
                if (attackCard.CardType == CardType.英雄)
                {
                    BaseHero attackHero = attackCard as BaseHero;
                    if (attackHero.Equip != null)
                    {
                        trueDamege += attackHero.Equip.Damage;
                    }
                }
                BaseActionParameter underAttackPara = CardActionFactory.CreateParameter(servant, actionParameter.GameContext, trueDamege, secondaryCard: attackCard);
                CardActionFactory.CreateAction(servant, ActionType.受到伤害).Action(underAttackPara);                
            }

            return null;
        }
    }
}
