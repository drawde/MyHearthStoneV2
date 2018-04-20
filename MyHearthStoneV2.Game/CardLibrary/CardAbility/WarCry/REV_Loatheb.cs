using MyHearthStoneV2.Game.Parameter;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.WarCry
{
    public class REV_Loatheb : IBaseCardAbility
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.BUFF;
        public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get; set; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.己方回合结束 };
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            actionParameter.MainCard.Cost -= 5;
            actionParameter.MainCard.Abilities.Remove(this);
            return null;
        }
    }
}
