using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BUFF.CardStatus;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BUFF.ChangeBody;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter.Servant;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Spell.Single;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;

using MyHearthStoneV2.Game.Widget.Direction;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Event.GameProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Warlock
{
    public class PowerOverwhelming : BaseSpell
    {
        public override Rarity Rare => Rarity.普通;

        public override string Name => "力量的代价";
        public override int Cost => 1;
        public override int InitialCost => 1;
        public override string Describe => "直到回合结束，使一个友方随从获得+4/+4，然后将其消灭。";

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new SpellDriver_Single_AllServant<
                ChangeDamageAndLife<SecondaryServantFilter,Four,Four,Plus,InDeskFilter,
                    Death<SecondaryServantFilter,InDeskFilter,MyTurnEndEvent>>>()            
        };

        public override string BackgroudImage => "Classical/PowerOverwhelming.jpg";
        public override Profession Profession => Profession.Warlock;
    }
}
