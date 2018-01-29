using System.Collections.Generic;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Controler;
using MyHearthStoneV2.Game.Parameter;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.WarCry.AlterBody
{
    public class CA_JiaoXiaoDeZhongShi : BaseCardAbility
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
                servant.Abilities.Add(new REV_JiaoXiaoDeZhongShi());
            }
            return null;
        }
    }
}
