using System.Collections.Generic;
using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;


namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Aura
{
    public class CA_DireWolfAlpha : ICardAbility
    {
        public AbilityType AbilityType { get; set; } = AbilityType.光环;
        public PriorityOfSettlement PriorityOfSettlement { get; set; }
        public CastStyle CastStyle { get; set; }
        public CastCrosshairStyle CastCrosshairStyle { get; set; }
        public List<SpellCardAbilityTime> SpellCardAbilityTimes { get; set; }

        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            UserContext player = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.MainCard);
            BaseServant servant = actionParameter.MainCard as BaseServant;

            //先暂时这样写，等Buff系统完工后再修改
            if (servant.DeskIndex != 1 && servant.DeskIndex != 8)
            {
                if (actionParameter.GameContext.DeskCards[servant.DeskIndex - 1] is BaseServant left)
                {
                    left.Damage += 1;
                    left.Abilities.Add(new REV_DireWolfAlpha());
                    if (left.Damage == 1)
                    {
                        BaseActionParameter para = CardActionFactory.CreateParameter(left, actionParameter.GameContext);
                        CardActionFactory.CreateAction(left, ActionType.重置攻击次数).Action(para);
                    }
                }
            }
            if (servant.DeskIndex != 7 && servant.DeskIndex != 15)
            {
                if (actionParameter.GameContext.DeskCards[servant.DeskIndex + 1] is BaseServant right)
                {
                    right.Damage += 1;
                    right.Abilities.Add(new REV_DireWolfAlpha());
                    if (right.Damage == 1)
                    {
                        BaseActionParameter para = CardActionFactory.CreateParameter(right, actionParameter.GameContext);
                        CardActionFactory.CreateAction(right, ActionType.重置攻击次数).Action(para);
                    }
                }
            }
            return null;
        }
    }
}
