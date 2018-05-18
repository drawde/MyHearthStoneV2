using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter.Hero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Spell;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Rogue
{
    public class DeadlyPoison : BaseSpell
    {
        public override Rarity Rare => Rarity.普通;

        public override string Name => "致命药膏";
        public override int Cost => 1;
        public override int InitialCost => 1;
        public override string Describe => "使你的武器获得+2攻击力。";

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new NoneTargetSpellDriver<UpgradeWeapon<PrimaryHeroFilter,Two,Zero>>()
        };

        public override string BackgroudImage => "Classical/DeadlyPoison.jpg";
        public override Profession Profession => Profession.Rogue;
    }
}
