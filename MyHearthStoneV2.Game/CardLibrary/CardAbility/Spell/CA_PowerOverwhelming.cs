using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Servant;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Parameter;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Spell
{
    public class CA_PowerOverwhelming : IBaseCardAbility
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.法术;
        public override CastCrosshairStyle CastCrosshairStyle => CastCrosshairStyle.单个;
        public override CastStyle CastStyle => CastStyle.随从;
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            BaseServant servant = actionParameter.SecondaryCard as BaseServant;
            servant.Life += 4;
            servant.BuffLife += 4;
            servant.Damage += 4;

            servant.Abilities.Add(new Death<SecondaryServantFilter>()
            {
                SpellCardAbilityTimes = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.己方回合结束 },                
            });
            return null;
        }
    }
}
