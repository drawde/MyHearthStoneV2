using MyHearthStoneV2.Game.Parameter;
using System.Collections.Generic;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.Servant;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Observer
{
    public class REV_EdwinVanCleef : BaseCardAbility
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.BUFF;
        public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get; set; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.己方回合结束 };
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            if (actionParameter.MainCard.CardLocation == CardLocation.手牌)
            {
                BaseServant servant = actionParameter.MainCard as BaseServant;
                servant.Life = servant.InitialLife;
                servant.BuffLife = servant.InitialLife;
                servant.Damage = servant.InitialDamage;                
            }
            return null;
        }
    }
}
