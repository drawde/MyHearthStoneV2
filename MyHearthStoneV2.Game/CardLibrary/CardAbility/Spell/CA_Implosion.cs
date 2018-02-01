using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Controler;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.CardLibrary.Servant.Warlock;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Controler;
using MyHearthStoneV2.Game.Context;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Spell
{
    public class CA_Implosion : BaseCardAbility
    {
        public override CastStyle CastStyle { get; set; } = CastStyle.敌方随从;

        public override AbilityType AbilityType { get; set; } = AbilityType.法术;
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            BaseServant servant = actionParameter.SecondaryCard as BaseServant;
            int damage = RandomUtil.CreateRandomInt(2, 4);
            var para = CardActionFactory.CreateParameter(servant, actionParameter.GameContext, damage, secondaryCard: actionParameter.MainCard);
            CardActionFactory.CreateAction(servant, ActionType.受到伤害).Action(para);
            bool isActivation = actionParameter.GameContext.IsThisActivationUserCard(actionParameter.MainCard);
            for (int i = 0; i < damage; i++)
            {                
                CreateNewGenericCardInDeskAction<Imp> action = new CreateNewGenericCardInDeskAction<Imp>();
                ControlerActionParameter newCardPara = new ControlerActionParameter()
                {
                    GameContext = actionParameter.GameContext,
                    IsActivation = isActivation,
                };
                action.Action(newCardPara);
            }
            return null;
        }
    }
}
