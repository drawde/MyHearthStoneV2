using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    public class RiseDamage : BaseCardAbility
    {
        public override CastStyle CastStyle { get; set; } = CastStyle.随从;
        public override CastCrosshairStyle CastCrosshairStyle { get; set; } = CastCrosshairStyle.单个;

        public override AbilityType AbilityType { get; set; } = AbilityType.战吼;
        public virtual int Damage { get; set; } = 1;
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            BaseBiology biology = actionParameter.SecondaryCard as BaseBiology;
            var para = CardActionFactory.CreateParameter(biology, actionParameter.GameContext, Damage, secondaryCard: actionParameter.MainCard);
            CardActionFactory.CreateAction(biology, ActionType.受到伤害).Action(para);
            return null;
        }
    }
}
