using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.CardLibrary.Spell;
using MyHearthStoneV2.Game.Parameter;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Spell
{
    public class CA_InnerRage : BaseCardAbility
    {
        public override CastStyle CastStyle { get; set; } = CastStyle.随从;
        public override CastCrosshairStyle CastCrosshairStyle { get; set; } = CastCrosshairStyle.单个;

        public override AbilityType AbilityType { get; set; } = AbilityType.法术;
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            BaseServant servant = actionParameter.SecondaryCard as BaseServant;
            if (servant.DeskIndex > -1 && servant.DeskIndex != 0 && servant.DeskIndex != 8)
            {
                servant.Damage += 2;
                //card.Buffs.Add(sourceCard, new REV_JiaoXiaoDeZhongShi());
                var para = CardActionFactory.CreateParameter(servant, actionParameter.GameContext, (actionParameter.MainCard as BaseSpell).Damage, secondaryCard: actionParameter.MainCard);
                CardActionFactory.CreateAction(servant, ActionType.受到法术伤害).Action(para);
                servant.Abilities.Add(new REV_InnerRage());
                BaseActionParameter respara = CardActionFactory.CreateParameter(servant, actionParameter.GameContext);
                CardActionFactory.CreateAction(servant, ActionType.重置攻击次数).Action(respara);
            }
            return null;
        }
    }
}
