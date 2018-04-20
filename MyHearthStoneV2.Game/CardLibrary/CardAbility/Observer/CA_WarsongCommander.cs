using System.Collections.Generic;
using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Parameter;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Observer
{
    public class CA_WarsongCommander : IBaseCardAbility
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.触发;
        public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get; set; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.己方随从入场 };
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            if (actionParameter.SecondaryCard.CardType == CardType.随从)
            {
                BaseServant servant = actionParameter.SecondaryCard as BaseServant;
                if (servant.Damage < 4)
                {
                    BaseActionParameter para = CardActionFactory.CreateParameter(servant, actionParameter.GameContext);
                    CardActionFactory.CreateAction(servant, ActionType.重置攻击次数).Action(para);
                    //servant.RemainAttackTimes = 1;
                }
            }
            return null;
        }
    }
}
