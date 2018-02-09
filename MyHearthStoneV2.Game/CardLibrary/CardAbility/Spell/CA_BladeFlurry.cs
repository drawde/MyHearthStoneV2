using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Spell
{
    public class CA_BladeFlurry : BaseCardAbility
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.法术;
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            GameContext gameContext = actionParameter.GameContext;
            UserContext enemy = gameContext.GetEnemyUserContextByMyCard(actionParameter.MainCard);
            UserContext user = gameContext.GetUserContextByMyCard(actionParameter.MainCard);
            BaseHero hero = gameContext.DeskCards.GetHeroByIsFirst(user.IsFirst);
            int damage = hero.Damage + hero.Equip.Damage;            
            hero.Equip.Durable = 0;
            foreach (var biology in actionParameter.GameContext.DeskCards.GetDeskBiologysByIsFirst(enemy.IsFirst).OrderBy(c => c.CastIndex))
            {
                BaseActionParameter para = CardActionFactory.CreateParameter(biology, actionParameter.GameContext, damage, secondaryCard: actionParameter.MainCard);
                CardActionFactory.CreateAction(biology, ActionType.受到法术伤害).Action(para);
            }
            var uc = gameContext.GetUserContextByMyCard(actionParameter.MainCard);
            
            return null;
        }
    }
}
