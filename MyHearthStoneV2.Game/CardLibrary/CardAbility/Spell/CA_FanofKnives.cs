using System.Linq;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.Spell;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter.Player;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Player;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Spell
{
    public class CA_FanofKnives : BaseCardAbility
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.法术;
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            GameContext gameContext = actionParameter.GameContext;
            UserContext enemy = gameContext.GetEnemyUserContextByMyCard(actionParameter.MainCard);

            foreach (var servant in actionParameter.GameContext.DeskCards.GetDeskServantsByIsFirst(enemy.IsFirst).OrderBy(c => c.CastIndex))
            {
                BaseActionParameter para = CardActionFactory.CreateParameter(servant, actionParameter.GameContext, (actionParameter.MainCard as BaseSpell).Damage, secondaryCard: actionParameter.MainCard);
                CardActionFactory.CreateAction(servant, ActionType.受到法术伤害).Action(para);
            }
            var uc = gameContext.GetUserContextByMyCard(actionParameter.MainCard);
            DrawCardActionParameter drawPara = new DrawCardActionParameter()
            {
                DrawCount = 1,
                GameContext = actionParameter.GameContext,
                UserContext = uc
            };
            new DrawCardAction().Action(drawPara);
            return null;
        }
    }
}
