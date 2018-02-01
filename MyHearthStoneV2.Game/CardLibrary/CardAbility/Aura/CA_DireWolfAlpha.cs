using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;


namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Aura
{
    public class CA_DireWolfAlpha : BaseCardAbility
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.光环;
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            UserContext player = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.MainCard);
            BaseServant servant = actionParameter.MainCard as BaseServant;

            //先暂时这样写，等Buff系统完工后再修改
            if (servant.DeskIndex != 2 && servant.DeskIndex != 9)
            {
                if (actionParameter.GameContext.DeskCards[servant.DeskIndex - 1] is BaseServant left)
                {
                    left.Damage += 1;
                    left.BuffDamage += 1;
                }
            }
            if (servant.DeskIndex != 8 && servant.DeskIndex != 15)
            {
                if (actionParameter.GameContext.DeskCards[servant.DeskIndex - 1] is BaseServant right)
                {
                    right.Damage += 1;
                    right.BuffDamage += 1;
                }
            }
            return null;
        }
    }
}
