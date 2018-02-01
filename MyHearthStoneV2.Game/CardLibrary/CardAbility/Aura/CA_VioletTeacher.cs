using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.Spell;
using MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical;
using MyHearthStoneV2.Game.Controler;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Controler;
using MyHearthStoneV2.Game.Parameter.Controler;
using MyHearthStoneV2.Game.Parameter;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Aura
{
    public class CA_VioletTeacher : BaseCardAbility
    {
        public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get; set; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.己方打出法术牌前 };
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            //必须是自己打出的法术类牌才能触发自己的紫罗兰教师的技能
            if (actionParameter.GameContext.IsThisActivationUserCard(actionParameter.SecondaryCard) &&
                actionParameter.GameContext.IsThisActivationUserCard(actionParameter.MainCard) && actionParameter.SecondaryCard is BaseSpell)
            {
                var player = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.MainCard);
                if (actionParameter.GameContext.DeskCards.GetDeskCardsByMyCard(actionParameter.MainCard as BaseBiology).Any(c => c == null))
                {
                    actionParameter.GameContext.AddActionStatement(new CreateNewGenericCardInDeskAction<VioletStudent>(), actionParameter);
                    //VioletStudent student = new CreateNewCardInDeskAction<VioletStudent>().Action(new ControlerActionParameter() { IsActivation = true }) as VioletStudent;
                }
            }
            return null;
        }
    }
}
