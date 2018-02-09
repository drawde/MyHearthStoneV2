using MyHearthStoneV2.Game.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.Spell;
using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.Servant;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Observer
{
    public class CA_WildPyromancer : BaseCardAbility
    {
        public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get; set; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.己方打出法术牌后 };
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            //必须是自己打出的法术类牌才能触发
            if (actionParameter.GameContext.IsThisActivationUserCard(actionParameter.SecondaryCard) &&
                actionParameter.GameContext.IsThisActivationUserCard(actionParameter.MainCard) && actionParameter.SecondaryCard is BaseSpell)
            {
                foreach (var bio in actionParameter.GameContext.DeskCards.GetServants())
                {
                    BaseServant servant = bio as BaseServant;
                    var para = CardActionFactory.CreateParameter(servant, actionParameter.GameContext, 1, secondaryCard: actionParameter.MainCard);
                    CardActionFactory.CreateAction(servant, ActionType.受到伤害).Action(para);
                }
            }
            return null;
        }
    }
}
