using MyHearthStoneV2.Game.Parameter;
using System.Collections.Generic;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.Servant;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Observer
{
    public class CA_EdwinVanCleef : BaseCardAbility
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.触发;
        public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get; set; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.己方随从入场, SpellCardAbilityTime.己方打出法术牌前 };
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            var user = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.MainCard);
            if (user.ComboSwitch && actionParameter.MainCard.CardLocation == CardLocation.手牌)
            {
                BaseServant servant = actionParameter.MainCard as BaseServant;
                servant.Life += 2;
                servant.BuffLife += 2;
                servant.Damage += 2;
            }
            return null;
        }
    }
}
