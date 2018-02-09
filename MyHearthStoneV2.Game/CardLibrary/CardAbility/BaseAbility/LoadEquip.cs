using MyHearthStoneV2.Game.CardLibrary.CardAction.Controler;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Equip;
using MyHearthStoneV2.Game.CardLibrary.Equip;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Controler;
using MyHearthStoneV2.Game.Parameter.Equip;
using MyHearthStoneV2.Game.Context;
namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    /// <summary>
    /// 装备一件武器
    /// </summary>
    /// <typeparam name="E"></typeparam>
    internal class LoadEquip<E> : BaseCardAbility where E : BaseEquip
    {
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            BaseHero hero = actionParameter.GameContext.DeskCards.GetHeroByMyCard(actionParameter.MainCard as BaseBiology);
            ControlerActionParameter ctlPara = new ControlerActionParameter()
            {
                GameContext = actionParameter.GameContext,
                UserContext = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.MainCard)
            };

            E equip = new CreateNewCardInControllerAction<E>().Action(ctlPara) as E;
            EquipActionParameter para = new EquipActionParameter()
            {
                GameContext = actionParameter.GameContext,
                Equip = equip,
                Hero = hero,
            };
            new LoadAction().Action(para);
            return null;
        }
    }
}
