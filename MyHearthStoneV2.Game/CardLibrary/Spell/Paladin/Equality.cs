using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Spell;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.Widget.Filter.Context;
using MyHearthStoneV2.Game.Widget.Filter.Servant;
using MyHearthStoneV2.Game.Widget.Number;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Paladin
{
    public class Equality : BaseSpell
    {
        public override Rarity Rare => Rarity.史诗;

        public override string Name => "生而平等";
        public override int Cost => 2;
        public override int InitialCost => 2;
        public override string Describe => "将所有随从的生命值变为1。";

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new NoneTargetSpellDriver
            <
                SetLife<PrimaryUserContextFilter,InDeskFilter,NullServantFilter,ONE>
            >(),
        };

        public override string BackgroudImage => "Paladin/Equality.jpg";
        public override Profession Profession => Profession.Paladin;
    }
}
