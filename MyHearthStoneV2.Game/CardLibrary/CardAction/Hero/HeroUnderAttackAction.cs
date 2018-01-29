using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.CardAbility;
using MyHearthStoneV2.Game.Parameter.Hero;
using System.Linq;

namespace MyHearthStoneV2.Game.CardLibrary.CardAction.Hero
{
    /// <summary>
    /// 被攻击
    /// </summary>
    internal class HeroUnderAttackAction : IGameAction
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            HeroActionParameter para = actionParameter as HeroActionParameter;
            BaseHero baseHero = para.Biology;
            GameContext gameContext = para.GameContext;
            BaseBiology attackCard = para.SecondaryCard as BaseBiology;
            if (attackCard.Abilities.Any(c => c.SpellCardAbilityTimes.Any(x => x == SpellCardAbilityTime.己方英雄受到伤害后)))
            {
                var abiliti = attackCard.Abilities.First(c =>
                    c.SpellCardAbilityTimes.Any(x => x == SpellCardAbilityTime.己方英雄受到伤害后));
                CardAbilityParameter cardPara = new CardAbilityParameter()
                {
                    GameContext = gameContext,
                    MainCard = baseHero,
                    SecondaryCard = attackCard
                };
                abiliti.Action(cardPara);
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
                BaseActionParameter underAttackPara = CardActionFactory.CreateParameter(baseHero, actionParameter.GameContext, trueDamege, secondaryCard: attackCard);
                CardActionFactory.CreateAction(baseHero, ActionType.受到伤害).Action(underAttackPara);
            }
            return null;
        }
    }
}
