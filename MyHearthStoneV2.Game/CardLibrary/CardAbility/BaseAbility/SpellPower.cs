using MyHearthStoneV2.Game.CardLibrary.CardAbility.AbilityAttribute;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    public class SpellPower : DefaultAttribute, ICardAbility
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.法术强度;
        public int Damage { get; set; } = 1;

        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            return null;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
