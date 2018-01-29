using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Player;
using System.Collections.Generic;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Player;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Action;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.WarCry.AlterBody
{
    public class CA_CruelTaskmaster : BaseCardAbility
    {
        public override CastStyle CastStyle { get; set; } = CastStyle.随从;
        public override CastCrosshairStyle CastCrosshairStyle { get; } = CastCrosshairStyle.单个;

        public override AbilityType AbilityType { get; set; } = AbilityType.战吼;
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            BaseServant servant = actionParameter.SecondaryCard as BaseServant;
            if (servant.DeskIndex > -1 && servant.DeskIndex != 0 && servant.DeskIndex != 8)
            {
                servant.Damage += 2;
                servant.BuffDamage += 2;
                //card.Buffs.Add(sourceCard, new REV_JiaoXiaoDeZhongShi());
                var para = CardActionFactory.CreateParameter(servant, actionParameter.GameContext, 1, secondaryCard: actionParameter.MainCard);
                CardActionFactory.CreateAction(servant, ActionType.受到伤害).Action(para);
                servant.Abilities.Add(new REV_CruelTaskmaster());
            }
            return null;
        }
    }
}
