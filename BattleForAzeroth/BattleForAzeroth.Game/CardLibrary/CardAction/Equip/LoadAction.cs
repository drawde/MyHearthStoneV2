using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.CardLibrary.Equip;
using BattleForAzeroth.Game.CardLibrary.Hero;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Parameter;
namespace BattleForAzeroth.Game.CardLibrary.CardAction.Equip
{
    public class LoadAction : Action.IGameAction
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            BaseHero baseHero = actionParameter.Hero;
            GameContext gameContext = actionParameter.GameContext;
            BaseEquip equip = actionParameter.Equip;

            if (baseHero.Equip != null)
            {
                var oldEquip = baseHero.Equip;

                UnloadAction unloadAction = new UnloadAction();
                var equipPara = new ActionParameter()
                {
                    GameContext = gameContext,
                    Equip = oldEquip,
                };
                unloadAction.Action(equipPara);
            }
            baseHero.Equip = equip;

            var user = gameContext.GetUserContextByMyCard(equip);
            gameContext.CastCardCount++;
            equip.CastIndex = gameContext.CastCardCount;
            equip.CardLocation = CardLocation.场上;

            ActionParameter resetPara = new ActionParameter
            {
                PrimaryCard = baseHero,
                GameContext = actionParameter.GameContext
            };
            CardActionFactory.CreateAction(baseHero, ActionType.重置攻击次数).Action(resetPara);
            return null;
        }
    }
}
